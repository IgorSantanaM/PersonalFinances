using PersonalFinances.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Mail
{
    public interface IMailer
    {
        Task SendAccountCreatedConfirmationAsync(Account account, CancellationToken token);
    }
}
