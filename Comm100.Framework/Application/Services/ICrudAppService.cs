using Comm100.Application.Dto;
using Comm100.Domain.Entity;
using Comm100.Runtime.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Comm100.Application.Services
{
    public interface ICrudAppService<TKey,TEntityDto, TEntityAddDto, TEntityUpdateDto,TEntityQueryInputDto,TEntityPageQueryInputDto> : IAppService
        where TEntityDto:IEntityDto<TKey>
        where  TEntityUpdateDto:IEntityDto<TKey>
        where TEntityQueryInputDto:IIncludeInput
        where TEntityPageQueryInputDto: TEntityQueryInputDto, ISortingAndPagingRequest
    {

        TEntityDto Get(TKey id, string include);
        IList<TEntityDto> GetList(TEntityQueryInputDto input =default);
        IPagedResult<TEntityDto> GetPagedList(TEntityPageQueryInputDto input);

        TEntityDto Add( TEntityAddDto dto);
        TEntityDto Update( TEntityUpdateDto dto);

        int Delete(TKey id);



    }
}
