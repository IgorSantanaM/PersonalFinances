    using FluentValidation;
using PersonalFinances.Domain.Core.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PersonalFinances.Domain.Accounts
{
    public class Account : Entity<Account>
    {
        public Account(string name, AccountType accountType, int balance, bool reconcile, List<Category>? categories)
        {
            Id = Guid.NewGuid();
            Name = name;
            Balance = balance;
            AccountType = accountType;
            Reconcile = reconcile;
            Categories = categories;
        }

        public string Name { get; set; }

        public AccountType AccountType { get; set; }

        public int Balance { get; set; }

        public bool Reconcile { get; set; }

        public List<Category>? Categories { get; set; } = new();

        public override bool IsValidate()
        {
            ValidateAccount();
            return ValidationResult.IsValid;
        }

        public void ValidateAccount()
        {
            NameValidation();
            BalanceValidation();
            ReconcileValidation();
            ValidationResult = Validate(this);
        }

        public void ReconcileValidation()
        {
                RuleFor(c => c.Reconcile)
                    .Must((c, reconcile) => !reconcile || c.Balance < 0)
                    .WithMessage("Reconcile is only true when initial balance is less than 0");
        }

        private void NameValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name required")
                .Length(2, 100).WithMessage("The Account name must be between 2 and 100 chars.");
        }
        private void BalanceValidation()
        {
            RuleFor(c => c.Balance)
                .InclusiveBetween(1, 2500000)
                .WithMessage("The initial balance should be between 1 and 2.500.000");
        }
    }
}
