using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Mail
{
    public interface IMailSender
    {
        Task<string> SendAsync(MimeMessage message);
        Task<string> SendAsync(MimeMessage message, CancellationToken token);
    }
}
