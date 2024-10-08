﻿using Events.IO.Domain.Core.Models;
using System.Linq.Expressions;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void AddAsync(TEntity obj);
        TEntity GetEntityByIdAsync(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();

    }
}
