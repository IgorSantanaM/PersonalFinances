using PersonalFinances.Domain.Accounts;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Services.DTOs
{
    public class AccountForCreationDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public AccountType AccountType { get; set; }

        [Required]
        [Range(1, 2500000)]
        public int InitialBalance { get; set; }

        public bool Reconcile { get; set; }

        public AccountForCreationDto(string name, int initialBalance, bool reconcile, AccountType accountType)
        {
            Id = Guid.NewGuid();
            Name = name;
            InitialBalance = initialBalance;
            AccountType = accountType;
            Reconcile = reconcile;
        }
    }
}
