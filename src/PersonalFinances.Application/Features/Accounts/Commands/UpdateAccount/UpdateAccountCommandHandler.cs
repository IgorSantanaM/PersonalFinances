using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PersonalFinances.Application.Exceptions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
    {
        private readonly IRepository<Account, AccountDocument> _repository;

        public UpdateAccountCommandHandler(IRepository<Account, AccountDocument> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {

            var accountToUpdate = await _repository.GetEntityByIdAsync(request.AccountId); 

            if(accountToUpdate is null)
            {
                throw new NotFoundException(nameof(Account), request.AccountId);
            }

            var validator = new UpdateAccountCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                var failures = new List<ValidationFailure>
                {
                    new ValidationFailure(nameof(request.Name), "Invalid account details.")
                };

                throw new ValidationException(failures);
            }

            await _repository.UpdateAsync(accountToUpdate);

            return Unit.Value;
        }
    }
}
