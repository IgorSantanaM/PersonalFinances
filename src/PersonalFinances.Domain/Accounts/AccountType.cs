namespace PersonalFinances.Domain.Account
{
    public class AccountType
    {
        public  Guid Id { get; set; }
        public string Type { get; set; }

        public AccountType(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }
    }
}
