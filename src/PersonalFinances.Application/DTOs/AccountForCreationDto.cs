using PersonalFinances.Domain.Accounts;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Application.DTOs
{
    public class AccountForCreationDto
    {
        [Required]
        public string Name { get; set; }

        public AccountType AccountType { get; set; }

        [Required]
        [Range(1, 2500000)]
        public int InitialBalance { get; set; }

        public bool Reconcile { get; set; }

        public AccountForCreationDto(string name, AccountType accountType, int initialBalance, bool reconcile)
        {
            Name = name;
            AccountType = accountType;
            InitialBalance = initialBalance;
            Reconcile = reconcile;
        }
    }
}
