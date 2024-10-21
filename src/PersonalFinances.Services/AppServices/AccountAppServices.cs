using AutoMapper;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFincances.Domain.Core.Bus;
using PersonalFincances.Services.DTOs;
using System.Runtime.InteropServices;

namespace PersonalFinances.Services.Repository
{
    public class AccountAppServices : IAccountAppServices
    {
        private readonly IRepository<Account, AccountDocument> _repository;
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public AccountAppServices(IRepository<Account, AccountDocument> repository, IBus bus, IMapper mapper)
        {
            _repository = repository;
            _bus = bus;
            _mapper = mapper;
        }
        public async Task CreateAccountAsync(AccountForCreationDto accountForCreationDto)
        {
            Account account = _mapper.Map<Account>(accountForCreationDto);

            if (!account.IsValidate())
            {
                throw new Exception("Could not create the account");
            }

            await _repository.AddAsync(account);
        }

        public async Task<AccountDto> GetAccountAsync(Guid id)
        {
            var account = await _repository.GetEntityByIdAsync(id);

            AccountDto accountDto = _mapper.Map<AccountDto>(account);

            return accountDto;
        }

    }
}
