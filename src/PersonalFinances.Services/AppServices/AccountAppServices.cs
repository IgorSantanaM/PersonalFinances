using AutoMapper;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Core.Events;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Services.AppServices;
using PersonalFinances.Services.DTOs;

namespace PersonalFinances.Services.Repository
{
    public class AccountAppServices : IAccountAppServices
    {
        private readonly IRepository<Account, AccountDocument> _repository;
        private readonly IMapper _mapper;

        public AccountAppServices(IRepository<Account, AccountDocument> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAccountAsync(AccountForCreationDto accountForCreationDto)
        {
            Account account = new(accountForCreationDto.Id, accountForCreationDto.Name, accountForCreationDto.AccountType, accountForCreationDto.InitialBalance, accountForCreationDto.Reconcile);

            if (!account.IsValidate())
            {
                throw new Exception("Could not create the account");
            }

            await _repository.AddAsync(account);

            return account.Id;
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<AccountDto> GetAccountAsync(Guid id)
        {
            var account = await _repository.GetEntityByIdAsync(id);

            AccountDto accountDto = _mapper.Map<AccountDto>(account);

            return accountDto;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync()
        {
            var accounts = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }
    }
}
