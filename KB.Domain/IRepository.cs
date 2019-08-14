using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KB.Domain
{
    public interface IRepository<TId, TEntity>
    {
        TEntity Get(TId id);

        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetQuery();

        int Count(Expression<Func<TEntity, bool>> predicate);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        int Delete(TId id);

        int Delete(TEntity entity);

        int Delete(Expression<Func<TEntity, bool>> predicate);

        bool Exists(Expression<Func<TEntity, bool>> predicate);

    }
}
