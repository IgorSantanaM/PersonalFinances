using Events.IO.Domain.Core.Models;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Reflection.Metadata;

namespace PersonalFinances.Domain.Model
{
    public class Account : Entity<Account>
    {
        public Account(string name, int initialBalance, bool reconcile )
        {
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public AccountType Type { get; set; }

        [Required]
        [MinLength(1000)]
        public int InitialBalance { get; set; } = 0;
        public int? Balance { get; set; }
        public bool Reconcile { get; set; }

        public ICollection<Category> Categories = new List<Category>();

        public override bool IsValidate()
        {
            ValidatingTheAccount();
            Authenticate();
            return ValidationResult.IsValid;
        }
        private void ValidatingTheAccount()
        {
            NameValidation();
        }
        private void NameValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name required")
                .Length(2, 100).WithMessage("The Account name must be between 2 and 100 chars.");
        }
        private void InitialBalanceValidation()
        {
            RuleFor(c => c.InitialBalance)
                .NotEmpty().WithMessage("The amount is not a valid number.");
        }
    }
}
