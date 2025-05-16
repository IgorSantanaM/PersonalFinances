using EasyNetQ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NodaTime;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Mail;
using PersonalFinances.Application.Messages;

public class MailSenderHostedService(IBus bus,
        IMailer mailer,
        IClock clock,
        ILogger<MailSenderHostedService> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
       => await bus.PubSub.SubscribeAsync<AccountForSendindMailDto>(
            "accountCreated",
            async data => await SendMailAsync(data, cancellationToken));

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    private async Task SendMailAsync(AccountForSendindMailDto data, CancellationToken token)
    {
        logger.LogDebug("received mail for sending: {AccountId}", data.Id);
        try
        {
            await mailer.SendAccountCreatedConfirmationAsync(data, token);
            await bus.PubSub.PublishAsync(new MailSuccess
            {
                AccountId = data.Id,
                MailSentAt = clock.GetCurrentInstant()
            }, CancellationToken.None);

            logger.LogDebug("Sent mail for {AccountId}", data.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error sending email for {AccountId}.", data.Id);
            await bus.PubSub.PublishAsync(new Mailfailure
            {
                AccountId = data.Id,
                MailError = ex.Message,
            }, CancellationToken.None);
        }
    }
}