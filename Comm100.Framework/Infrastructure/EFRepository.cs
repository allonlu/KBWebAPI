//-----------------------------------------------------------------------
// <copyright file="EFRepository.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Infrastructure
{
    using Comm100.Domain.Entity;
    using Comm100.Framework.Domain.Entity;
    using Comm100.Framework.Domain.Repository;
    using Comm100.Framework.Domain.Specifications;
    using Comm100.Framework.Tenants;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class EFRepository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class
    {
        protected readonly BaseDBContext _dbContext;

        public EFRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Count(ISpecification<TEntity> spec)
        {
            return ApplySpecification(spec).Count();
        }

        public TEntity Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity is ISoftDelete)
            {
                (entity as ISoftDelete).IsDeleted = false;
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }

            _dbContext.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
        }

        public TEntity Get(TId id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public bool Exists(TId id)
        {
            return Get(id) != null;
        }

        public IReadOnlyList<TEntity> ListAll()
        {
            return GetQueryable().ToList();
        }

        public IReadOnlyList<TEntity> List(ISpecification<TEntity> spec)
        {
            return ApplySpecification(spec).ToList();
        }

        private IQueryable<TEntity> GetQueryable()
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (typeof(IMultiSite).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Where(t => ((IMultiSite)t).SiteId == _dbContext.Tenant.Id);
            }

            return query;
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(GetQueryable(), spec);
        }
    }
}
