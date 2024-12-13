using AutoMapper;
using PersonalFinances.Domain.Accounts;
using PersonalFinances.Infra.Data.Mongo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances.Infra.Data.Mongo.Repository
{
    public class CategoryRepository : Repository<Category, CategoryDocument>
    {
        public CategoryRepository(IMapper mapper, IMongoRepository<CategoryDocument> mongoRepository) : base(mapper, mongoRepository)
        {
        }
    }
}
