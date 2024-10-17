using AutoMapper;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFincances.Domain.Core.Bus;
using PersonalFincances.Services.DTOs;

namespace PersonalFinances.Services.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IRepository<Account> _repository;
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IMongoRepository<AccountDocument> _mongo;

        public AccountRepository(IRepository<Account> repository, IBus bus, IMapper mapper, IMongoRepository<AccountDocument> mongo)
        {
            _repository = repository;
            _bus = bus;
            _mapper = mapper;
            _mongo = mongo;
        }
        public async Task CreateAccountAsync(CreateAccountDto createAccountDto)
        {
            Account account = _mapper.Map<Account>(createAccountDto);

            if (!account.Validate())
            {
                throw new Exception("Could not create the account");
            }

            _repository.Add(account);
            _repository.SaveChanges();

            AccountDto accountDto = _mapper.Map<AccountDto>(account);
            
            AccountDocument accountDocument = _mapper.Map<AccountDocument>(account);

           await _mongo.InsertOneAsync(accountDocument);
        }

        public async Task<AccountDto> GetAccountAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
