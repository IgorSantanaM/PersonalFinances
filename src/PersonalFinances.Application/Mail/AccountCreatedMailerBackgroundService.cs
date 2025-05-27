using EasyNetQ;
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
        IMailDeliveryReporter reporter,
        IBus bus) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        => await ProcessMailQueue(stoppingToken);

        private async Task ProcessMailQueue(CancellationToken stoppingToken)
        {
            AccountForSendingMailDto accountMail;
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
                    var mailData = new AccountForSendingMailDto()
                    {   
                        Id = account.Id,
                        Name = account.Name,
                        AccountType = account.AccountType,
                        Balance = account.Balance,
                        Reconcile = account.Reconcile
                    };
                    await bus.PubSub.PublishAsync(mailData, stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error sending email for {AccountId}.", accountMail.Id);
                    await reporter.ReportFailureAsync(accountMail.Id, ex.Message);
                }
            }
        }
}
}
