using AutoMapper;
using MediatR;
using PersonalFinances.Application.Exceptions;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;

namespace PersonalFinances.Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit>
    {
        private readonly IRepository<Account, AccountDocument> _repository;
        public DeleteAccountCommandHandler(IRepository<Account, AccountDocument> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToDelete = await _repository.GetEntityByIdAsync(request.AccountId);

            if (accountToDelete is null)
            {
                throw new NotFoundException(nameof(Account), request.AccountId);
            }

            await _repository.RemoveAsync(accountToDelete.Id);

            return Unit.Value;
        }
    }
}
