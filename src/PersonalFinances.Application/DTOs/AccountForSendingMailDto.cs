using PersonalFinances.Domain.Accounts;

namespace PersonalFinances.Application.DTOs
{
    public class AccountForSendingMailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }    
        public int Balance { get; set; }
        public bool Reconcile { get; set; }
    }
}
