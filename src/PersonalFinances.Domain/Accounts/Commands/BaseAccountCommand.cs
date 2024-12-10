using PersonalFinances.Domain.Core.Commands;

namespace PersonalFinances.Domain.Accounts.Commands
{
    public class BaseAccountCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public int InitialBalance { get; set; } = 0;
        public int? Balance { get; set; }
        public bool Reconcile { get; set; }

        public ICollection<Category> Categories = new List<Category>();
    }
}
