using AutoMapper;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.Data.Mongo.Repository
{
    public class AccountRepository : Repository<Account, AccountDocument>
    {
        public AccountRepository(IMapper mapper, IMongoRepository<AccountDocument> mongoRepository) : base(mapper, mongoRepository)
        {
        }
    }
}
