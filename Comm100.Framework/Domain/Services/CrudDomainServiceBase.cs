using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comm100.Domain.Entity;
using Comm100.Domain.Repository;
using Comm100.Extension;
using Comm100.Runtime.Dto;
using Comm100.Runtime.Transactions;

namespace Comm100.Domain.Services
{
    public abstract class CrudDomainServiceBase<TKey, TEntity, TEntityBase, TEntityQueryInput> 
            : DomainServiceBase,ICrudDomainService<TKey, TEntity, TEntityBase, TEntityQueryInput>
        where TEntityBase : IEntity<TKey>
        where TEntity : TEntityBase
        where TEntityQueryInput : IIncludeInput,new()
    {
        protected readonly IRepository<TKey, TEntity> repository;

        public CrudDomainServiceBase(IRepository<TKey,TEntity> repository)
        {
            this.repository = repository;
        }
        [Transaction(System.Transactions.IsolationLevel.Serializable)]
        public virtual TEntityBase Add(TEntityBase entity)
        {
            var newEntity = entity.MapTo<TEntity>();        //** n should not be used.
            return repository.Insert(newEntity);
        }


        public virtual int Count(TEntityQueryInput input)
        {
            var query = GetQueryable(input);
            return query.Count();
        }

        public virtual int Delete(TKey id)
        {
            return repository.Delete(id);
        }


        public virtual TEntityBase Get(TKey id)
        {

            return repository.Get(id);
        }



        public virtual TEntity Get(TKey id,string include)
        {
            var query = repository.GetAll(e => e.Id.Equals(id));
            query = AddInclude(query,include);
            return query.FirstOrDefault();
        }

        public virtual IList<TEntity> GetList(TEntityQueryInput input)
        {
            if (input == null) input = new TEntityQueryInput();
            var query = GetQueryable(input);
            query = AddInclude(query, input.Include);
            return query.ToList();
        }

        public virtual IPagedResult<TEntity> GetPagedList(TEntityQueryInput input,ISortingAndPagingRequest sortingAndPagingRequest)
        {
            var query = GetQueryable(input);
            var count = query.Count();
            query = AddInclude(query, input.Include);
            //query.SortingAndPaging(sortingAndPagingRequest);
            return new PagedResultDto<TEntity>(count, query.ToList());
        }

        public virtual TEntityBase Update(TEntityBase entity)
        {
            var updateEntity = repository.Get(entity.Id);
            updateEntity.Modify(entity);
            return repository.Update(updateEntity);
        }
        protected IQueryable<TEntity> AddInclude(IQueryable<TEntity> query, string include)
        {
            foreach (string resourceName in include.AnalyzeInclude())
            {
                query=HandleInclude(query, resourceName);
            }
            return query;
        }
        protected  IQueryable<TEntity> GetQueryable(TEntityQueryInput input)
        {
            return HandleCondition(repository.GetAll(),input);
        }
        protected abstract IQueryable<TEntity> HandleCondition(IQueryable<TEntity> query, TEntityQueryInput input);
        protected abstract IQueryable<TEntity> HandleInclude(IQueryable<TEntity> query, string resourceName);
    }
}
