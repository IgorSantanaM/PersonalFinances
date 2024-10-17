using FluentValidation;
using PersonalFincances.Domain.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Domain.Accounts
{
    public class Category : Entity<Category>
    {

        public TransactionType? TransactionType { get; set; }

        public Account? BelongsTo { get; set; }

        public string Name { get; set; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public override bool Validate()
        {
            ValidatingTheCategory();
            return ValidationResult.IsValid;
        }

        private void ValidatingTheCategory()
        {
            NameValidation();
        }

        private void NameValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The Category name should not be null")
                .Length(2, 100).WithMessage("The Category name must be between 2 an 100");
        }

    }
}
