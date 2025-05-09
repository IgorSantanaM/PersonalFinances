using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Mapping;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;

namespace PersonalFinances.Application.Mail
{
    public class AccountCreatedMailerBackgroundService(
        IMailQueue queue,
        IServiceProvider services,
        ILogger<AccountCreatedMailerBackgroundService> logger,
        IMailer mailer,
        IMailDeliveryReporter reporter) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        => await ProcessMailQueue(stoppingToken);

        private async Task ProcessMailQueue(CancellationToken stoppingToken)
        {
            AccountForSendindMailDto accountMail;
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    accountMail = await queue.FetchMailFromQueueAsync(stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    logger.LogDebug("Exiting {ProcessMailQueue} due to OperationCanceledException (this is fine!)", nameof(ProcessMailQueue));
                    break;
                }
                using var scope = services.CreateScope();
                var sender = scope.ServiceProvider.GetRequiredService<IMailer>();
                var repository = scope.ServiceProvider.GetRequiredService<IRepository<Account, AccountDocument>>();
                try
                {
                    Account? account = await repository.GetEntityByIdAsync(accountMail.Id);
                    if (account is null) continue;
                    accountMail = DtoMapping.MapAccountToMailAccount(account);
                    try
                    {
                        await mailer.SendAccountCreatedConfirmationAsync(accountMail, stoppingToken);
                        await reporter.ReportSuccessAsync(accountMail.Id);
                    }catch(Exception)
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error sending email for {OrderId}.", accountMail.Id);
                    await reporter.ReportFailureAsync(accountMail.Id, ex.Message);
                }
            }
        }
}
}
