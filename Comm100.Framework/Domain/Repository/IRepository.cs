using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Comm100.Framework.Domain.Specifications;

namespace Comm100.Framework.Domain.Repository
{
    public interface IRepository<TId, TEntity>
    {
        TEntity Get(TId id);
        IReadOnlyList<TEntity> List(ISpecification<TEntity> spec);
        IReadOnlyList<TEntity> GetQuery();
        int Count(Expression<Func<TEntity, bool>> predicate);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        int Delete(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }
}
