using NodaTime;

namespace PersonalFinances.Application.Messages
{
    public class MailSuccess
    {
        public Guid AccountId { get; set; }
        public Instant MailSentAt { get; set; }
    }
}
