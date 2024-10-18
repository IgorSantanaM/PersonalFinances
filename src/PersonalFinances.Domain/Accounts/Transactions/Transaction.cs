using FluentValidation;
using PersonalFincances.Domain.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinances.Domain.Accounts.Transactions
{
    public class Transaction : Entity<Transaction>
    {
        public DateTime DateOfTransaction { get; set; }

        public Account Account { get; set; }

        public Category Category { get; set; }

        public int Amount { get; set; }

        public string? Remarks { get; set; }

        public Transaction(DateTime dateOfTransaction, int amount, string? remarks)
        {
            Id = Guid.NewGuid();
            DateOfTransaction = dateOfTransaction;
            Amount = amount;
            Remarks = remarks;
        }

        public override bool IsValidate()
        {
            ValidatingTransaction();
            return ValidationResult.IsValid;
        }
        private void ValidatingTransaction()
        {
            DateOfTransactionValidation();
            AmountValidation();
            RemarksValidation();
        }


        private void DateOfTransactionValidation()
        {
            RuleFor(c => c.DateOfTransaction)
                .NotEmpty()
                .LessThan(DateTime.UtcNow)
                .WithMessage("The transaction date cannot be in the past");
        }

        private void AmountValidation()
        {
            RuleFor(c => c.Amount)
                .NotEmpty()
                .ExclusiveBetween(1, 250000)
                .WithMessage("The transaction amount must be between 1.00 and 250,000.00");
                
        }
        
        private void RemarksValidation()
        {
            RuleFor(c => c.Remarks)
               .MaximumLength(250);
        }

    }
}
