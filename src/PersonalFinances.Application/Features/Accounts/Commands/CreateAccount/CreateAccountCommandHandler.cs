using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;

namespace PersonalFinances.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IRepository<Account, AccountDocument> _repository;

        public CreateAccountCommandHandler(IRepository<Account, AccountDocument> repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new(request.Name, request.AccountType, request.InitialBalance, request.Reconcile, request.Categories);

            if (!account.IsValidate())
            {
                var failures = new List<ValidationFailure>
                {
                    new ValidationFailure(nameof(request.Name), "Invalid account details.")
                };

                throw new ValidationException(failures);
            }

            await _repository.AddAsync(account);

            return account.Id;
        }
    }
}
