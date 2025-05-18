using PersonalFinances.Application.DTOs;
using PersonalFinances.Domain.Accounts;

namespace PersonalFinances.Application.Mail
{
    public interface IHtmlMailRenderer
    {
        string RenderHtmlEmail(AccountForSendingMailDto accountSendingMail);
    }
}
