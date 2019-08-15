using Comm100.Domain.Entity;
using Comm100.Runtime.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Domain.Services
{
    public interface ICrudDomainService<TKey,TEntity,TEntityBase,TEntityQueryInput>:IDomainService
        where TEntityBase:IEntity<TKey>
        where TEntity:TEntityBase
        where TEntityQueryInput:IIncludeInput
    {
        TEntityBase Get(TKey id);
        TEntity Get(TKey id,string include);
        IList<TEntity> GetList(TEntityQueryInput input);
        IPagedResult<TEntity> GetPagedList(TEntityQueryInput input, ISortingAndPagingRequest sortingAndPagingRequest);
        int Count(TEntityQueryInput input);

        TEntityBase Add(TEntityBase entity);
        TEntityBase Update(TEntityBase entity);

        int Delete(TKey id);






        

    }
}
