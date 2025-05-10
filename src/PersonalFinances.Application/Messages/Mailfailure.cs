namespace PersonalFinances.Application.Messages
{
    public class Mailfailure
    {
        public Guid AccountId { get; set; }
        public string MailError { get; set; } = string.Empty;
    }
}
