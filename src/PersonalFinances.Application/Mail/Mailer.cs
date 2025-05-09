using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using MimeKit;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Mail
{
    public class Mailer(IHtmlMailRenderer htmlRenderer,
        IMailSender sender,
        ILogger<Mailer> logger) : IMailer
    {

        public MimeMessage CreateMessage(Account account)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Igor", "igor@kinsoftware.dev"));
            message.To.Add(new MailboxAddress(account.Name, "example@example.com"));
            message.Subject = $"Your Account has been created!";
            var bb = new BodyBuilder
            {
                HtmlBody = htmlRenderer.RenderHtmlEmail(account)
            };

            message.Body = bb.ToMessageBody();
            return message;
        }
        public async Task SendAccountCreatedConfirmationAsync(Account account, CancellationToken token)
        {
            var message = CreateMessage(account);

            try
            {
                await sender.SendAsync(message, token);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error sending email for {AccountId}.", account.Id);
                throw;
            }
        }
    }
}
