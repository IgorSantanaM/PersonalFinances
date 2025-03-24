using AutoMapper;
using MediatR;
using PersonalFinances.Application.Features.Accounts.Commands.CreateAccount;
using PersonalFinances.Application.Features.Accounts.Commands.DeleteAccount;
using PersonalFinances.Application.Features.Accounts.Commands.UpdateAccount;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Application.DTOs;
using PersonalFinances.Application.Features.Accounts.Queries.GetAccountDetail;
using PersonalFinances.Application.Features.Accounts.Queries.GetAccountsList;

namespace PersonalFinances.Services.Repository
{
    public class AccountAppServices : IAccountAppServices
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountAppServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAccountAsync(AccountForCreationDto accountForCreationDto)
        {
            var createAccountCommand = _mapper.Map<CreateAccountCommand>(accountForCreationDto);
            var accountId = await _mediator.Send(createAccountCommand);

            return accountId;
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            DeleteAccountCommand deleteAccountComamnd = new() { AccountId = id };
            await _mediator.Send(deleteAccountComamnd);
        }

        public async Task<AccountDto> GetAccountAsync(Guid id)
        {
            GetAccountDetailQuery getAccountDetailQuery = new() { AccountId = id };
            var accountDto = await _mediator.Send(getAccountDetailQuery);

            return accountDto;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync()
        {
            var accountDtos = await _mediator.Send(new GetAccountsListQuery());

            return accountDtos;
        }

        public async Task UpdateAccountAsync(Guid id, AccountForUpdatingDto accountForUpdatingDto)
        {
            UpdateAccountCommand accountToUpdate = new() { AccountId = id, Name = accountForUpdatingDto.Name, Reconcile = accountForUpdatingDto.Reconcile, Balance = accountForUpdatingDto.Balance ,AccountType = accountForUpdatingDto.AccountType,  };
            await _mediator.Send(accountToUpdate);
        }
    }
}
