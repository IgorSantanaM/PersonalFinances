using FluentValidation;
using PersonalFinances.Domain.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Domain.Accounts
{
    public class Category : Entity<Category>
    {
        public TransactionType TransactionType { get; set; }

        public CategoryType BelongsTo { get; set; }

        public string Name { get; set; }

        public Category(string name, TransactionType transactionType, CategoryType belongsTo)
        {
            Id = Guid.NewGuid();
            TransactionType = transactionType;
            BelongsTo = belongsTo;
            Name = name;
        }

        public override bool IsValidate()
        {
            ValidatingTheAccount();
            return ValidationResult.IsValid;
        }

        private void ValidatingTheAccount()
        {
            NameValidation();
            ValidationResult = Validate(this);
        }

        private void NameValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The Category name should not be null")
                .Length(2, 100).WithMessage("The Category name must be between 2 an 100");
        }
    }
}
