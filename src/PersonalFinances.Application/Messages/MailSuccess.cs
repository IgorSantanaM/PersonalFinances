using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Messages
{
    public class MailSuccess
    {
        public Guid AccountId { get; set; }
        public Instant MailSentAt { get; set; }
    }
}
