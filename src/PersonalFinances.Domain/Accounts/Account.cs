using FluentValidation;
using PersonalFinances.Domain.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Domain.Accounts
{
    public class Account : Entity<Account>
    {

        public Account(Guid id, string name, int initialBalance, bool reconcile)
        {
            Id = Id;
            Name = name;
            InitialBalance = initialBalance;
            Reconcile = reconcile;
        }

        public string Name { get; set; }

        public AccountType Type { get; set; }

        public int InitialBalance { get; set; } = 0;

        public int? Balance { get; set; }

        public bool Reconcile { get; set; }


        public ICollection<Category> Categories = new List<Category>();

        public override bool IsValidate()
        {
            ValidatingTheAccount();
            return ValidationResult.IsValid;
        }

        private void ValidatingTheAccount()
        {
            NameValidation();
            InitialBalanceValidation();
            ValidationResult = Validate(this);
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
                .InclusiveBetween(0, 250000)
                .WithMessage("The initial balance should be between 0 and 250.000");
        }

    }
}
