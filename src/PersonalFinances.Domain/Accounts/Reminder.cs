using FluentValidation;
using PersonalFincances.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PersonalFinances.Domain.Accounts
{
    public class Reminder : Entity<Reminder>
    {

        public DateTime StartDate { get; set; }

        public Frequency Frequency { get; set; }

        public Category Category { get; set; }

        public int EstimatedAmount { get; set; }

        public string? Remarks { get; set; }

        public bool NumberOfRepetitions { get; set; }

        public Reminder(int estimatedAmount, string? remarks, bool numberOfRepetitions)
        {
            Id = Guid.NewGuid();
            EstimatedAmount = estimatedAmount;
            Remarks = remarks;
            NumberOfRepetitions = numberOfRepetitions;
        }
        public override bool Validate()
        {
            ValidatingReminder();
            return ValidationResult.IsValid;
        }

        private void ValidatingReminder()
        {
            EstimatedAmountValidation();
            RemarksValidation();
        }

        private void EstimatedAmountValidation()
        {
            RuleFor(c => c.EstimatedAmount)
                .NotEmpty().WithMessage("The estimated amount cannot be null")
                .ExclusiveBetween(1, 250000).WithMessage("The transaction amount must be between 1.00 and 250,000.00 ");
        }

        private void RemarksValidation()
        {
            RuleFor(c => c.Remarks)
             .MaximumLength(250);
        }
    }
}
