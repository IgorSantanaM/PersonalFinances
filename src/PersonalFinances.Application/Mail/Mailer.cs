using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using MimeKit;
using PersonalFinances.Application.DTOs;

namespace PersonalFinances.Application.Mail
{
    public class Mailer(IHtmlMailRenderer htmlRenderer,
        IMailSender sender,
        ILogger<Mailer> logger) : IMailer
    {

        public MimeMessage CreateMessage(AccountForSendingMailDto accountSendingMail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Igor", "igor@kinsoftware.dev"));
            message.To.Add(new MailboxAddress(accountSendingMail.Name, "example@example.com"));
            message.Subject = $"Your Account has been created!";
            var bb = new BodyBuilder
            {
                HtmlBody = htmlRenderer.RenderHtmlEmail(accountSendingMail)
                //HtmlBody = $"<h1> Thank you for creating the account! {accountSendingMail.Name} </h1>"
            };

            message.Body = bb.ToMessageBody();
            return message;
        }

        public async Task SendAccountCreatedConfirmationAsync(AccountForSendingMailDto accountSendingMail, CancellationToken token)
        {
            var message = CreateMessage(accountSendingMail);

            try
            {
                await sender.SendAsync(message, token);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error sending email for {AccountId}.", accountSendingMail.Id);
                throw;
            }
        }
    }
}
