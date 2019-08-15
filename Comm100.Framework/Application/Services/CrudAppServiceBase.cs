using Comm100.Application.Dto;
using Comm100.Domain.Entity;
using Comm100.Domain.Services;
using Comm100.Extension;
using Comm100.Runtime;
using Comm100.Runtime.Dto;
using Comm100.Runtime.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Application.Services
{
    public abstract class CrudAppServiceBase<TKey,TEntity,TEntityBase,TEntityQueryInput, TEntityDto, TEntityAddDto, TEntityUpdateDto, TEntityQueryInputDto, TEntityPageQueryInputDto>
        : AppServiceBase, ICrudAppService<TKey, TEntityDto, TEntityAddDto, TEntityUpdateDto, TEntityQueryInputDto, TEntityPageQueryInputDto>
        where TEntityBase : IEntity<TKey>
        where TEntity : TEntityBase
        where TEntityDto : IEntityDto<TKey>
        where TEntityUpdateDto : IEntityDto<TKey>
        where TEntityQueryInput:IIncludeInput
        where TEntityQueryInputDto :TEntityQueryInput
        where TEntityPageQueryInputDto : TEntityQueryInputDto, ISortingAndPagingRequest
      
    {
        protected readonly ICrudDomainService<TKey, TEntity, TEntityBase, TEntityQueryInput> domainService;

        public CrudAppServiceBase(ICrudDomainService<TKey, TEntity, TEntityBase, TEntityQueryInput> domainService)
        {
            this.domainService = domainService;
        }
        [Permission(nameof(TEntity)+".Add")]
        [Transaction(System.Transactions.IsolationLevel.Serializable)]
        public virtual TEntityDto Add(TEntityAddDto dto)
        {
            var newEntity= domainService.Add(dto.MapTo<TEntityBase>());
            return newEntity.MapTo<TEntityDto>();
        }
        [Permission(nameof(TEntity) + ".Delete")]
        public virtual int Delete(TKey id)
        {
            return domainService.Delete(id);
        }

        [Permission(nameof(TEntity) + ".Get")]
        public virtual TEntityDto Get(TKey id,string include)
        {
            return domainService.Get(id,include).MapTo<TEntityDto>();
        }

        [Permission(nameof(TEntity) + ".Get")]
        public virtual IList<TEntityDto> GetList(TEntityQueryInputDto input=default)
        {
            return domainService.GetList(input).MapTo<IList<TEntityDto>>();
        }

        [Permission(nameof(TEntity) + ".Get")]
        public virtual IPagedResult<TEntityDto> GetPagedList(TEntityPageQueryInputDto input)
        {
            var pageResult = domainService.GetPagedList(input, input);
            return pageResult.MapTo<TEntity, TEntityDto>();
        }

        [Permission(nameof(TEntity) + ".Update")]
        public virtual TEntityDto Update(TEntityUpdateDto dto)
        {
            var entity = domainService.Get(dto.Id);
            entity.ModifyBy(dto);
            domainService.Update(entity);
            return entity.MapTo<TEntityDto>();
        }
    }
}
