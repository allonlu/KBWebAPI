using Comm100.Framework.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Comm100.Framework.Infrastructure 
{
    public class EFRepository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class {

        protected DbContext _dbContext;
        protected DbSet<TEntity> _dataSet;

        public EFRepository(DbContext dbContext) 
        {
            _dbContext = dbContext;
            _dataSet = dbContext.Set<TEntity>();
        }
        public TEntity Get(TId id) {
            return _dataSet.Find(id);
        }
        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) return _dataSet.AsNoTracking();
            return _dataSet.AsNoTracking().Where(predicate);
        }
        public IQueryable<TEntity> GetQuery() {
            return _dataSet.AsQueryable();
        }
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) return _dataSet.Count(predicate);
            return _dataSet.Count(predicate);
        }
        public TEntity Create(TEntity entity) 
        {
            _dataSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            _dbContext.Update(entity);
            return entity;
        }

        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
