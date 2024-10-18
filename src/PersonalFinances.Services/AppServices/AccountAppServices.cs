using AutoMapper;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFincances.Domain.Core.Bus;
using PersonalFincances.Services.DTOs;

namespace PersonalFinances.Services.Repository
{
    public class AccountAppServices : IAccountAppServices
    {
        private readonly IRepository<Account> _repository;
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IMongoRepository<AccountDocument> _mongo;

        public AccountAppServices(IRepository<Account> repository, IBus bus, IMapper mapper, IMongoRepository<AccountDocument> mongo)
        {
            _repository = repository;
            _bus = bus;
            _mapper = mapper;
            _mongo = mongo;
        }
        public async Task CreateAccountAsync(AccountForCreationDto accountForCreationDto)
        {
            Account account = _mapper.Map<Account>(accountForCreationDto);

            if (!account.IsValidate())
            {
                throw new Exception("Could not create the account");
            }

            _repository.Add(account);

            //AccountDto accountDto = _mapper.Map<AccountDto>(account);
            
            AccountDocument accountDocument = _mapper.Map<AccountDocument>(account);

           await _mongo.InsertOneAsync(accountDocument);
        }

        public async Task<AccountDto> GetAccountAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
