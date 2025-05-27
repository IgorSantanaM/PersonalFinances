using System.Linq.Expressions;
using AutoMapper;
using MongoDB.Driver;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Mongo.Documents;
using PersonalFinances.Domain.Core.Model;
using PersonalFinances.Domain.Accounts;

namespace PersonalFinances.Infra.Data.Mongo.Repository
{

    public abstract class Repository<K, T> : IRepository<K, T>
        where T : IDocument, new()
        where K : Entity<K>
    {
        private readonly IMapper _mapper;

        private readonly IMongoRepository<T> _mongoRepository;


        protected Repository(IMapper mapper, IMongoRepository<T> mongoRepository)
        {
            _mapper = mapper;
            _mongoRepository = mongoRepository;
        }

        public virtual async Task AddAsync(K obj)
        {
           var document = _mapper.Map<T>(obj);

           await _mongoRepository.InsertOneAsync(document);
        }

        public virtual async Task<IEnumerable<K>> GetAllAsync()
        {
            var entities = await _mongoRepository.GetAllAsync();

            var accountList = _mapper.Map<List<K>> (entities);

            return accountList;
        }
        public virtual async Task<K?> GetEntityByIdAsync(Guid id)
        {
            T? document = await _mongoRepository.FindByIdAsync(id);    

            if(document is null)
            {
                return null;
            }

            return _mapper.Map<K>(document);
        }
        public virtual async Task RemoveAsync(Guid id)
        {
            await _mongoRepository.DeleteByIdAsync(id);
        }

        public virtual async Task UpdateAsync(K obj)
        {
            var document = _mapper.Map<T>(obj);
            await _mongoRepository.ReplaceOneAsync(document);
        }

    }
}
