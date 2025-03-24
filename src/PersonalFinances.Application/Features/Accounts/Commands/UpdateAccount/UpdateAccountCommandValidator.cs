using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(c => c.Reconcile)
                   .Must((c, reconcile) => !reconcile || c.Balance < 0)
                   .WithMessage("Reconcile is only true when initial balance is less than 0");

            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("Name required")
               .Length(2, 100).WithMessage("The Account name must be between 2 and 100 chars.");

            RuleFor(c => c.Balance)
               .InclusiveBetween(0, 2500000)
               .WithMessage("The initial balance should be between 0 and 2.500.000");
        }
    }
}
