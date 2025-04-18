﻿using PersonalFinances.Domain.Core.Model;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IRepository<K, T> where K : Entity<K>
    {

        Task AddAsync(K obj);

        Task<K?> GetEntityByIdAsync(Guid id);

        Task<IEnumerable<K>> GetAllAsync();

        Task UpdateAsync(K obj);
    
        Task RemoveAsync(Guid id);

    }
}
