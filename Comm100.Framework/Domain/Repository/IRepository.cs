using Comm100.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Comm100.Domain.Repository
{
    public interface IRepository<TKey,TEntity> where TEntity:IEntity<TKey>
    {
        TEntity Get(TKey id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        int Delete(TKey id);
        int Delete(TEntity entity);

        int Delete(Expression<Func<TEntity, bool>> predicate);

        bool Exists(Expression<Func<TEntity, bool>> predicate);
        int Count(Expression<Func<TEntity, bool>> predicate);

    }
    public interface IRepository<TEntity> : IRepository<Guid, TEntity> where TEntity : IGuidEntity { }
}
