using Comm100.Application.Dto;
using Comm100.Application.Services;
using Comm100.Runtime.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public abstract class CrudApiControllerBase<TKey, TEntityDto, TEntityAddDto, TEntityUpdateDto, TEntityQueryIntputDto, TEntityPageQueryInputDto> : Comm100ControllerBase
        where TEntityDto : IEntityDto<TKey>
        where TEntityUpdateDto : IEntityDto<TKey>
        where TEntityQueryIntputDto : IIncludeInput
        where TEntityPageQueryInputDto : TEntityQueryIntputDto, ISortingAndPagingRequest
    {
        protected readonly ICrudAppService<TKey, TEntityDto, TEntityAddDto, TEntityUpdateDto, TEntityQueryIntputDto, TEntityPageQueryInputDto> appService;

        public CrudApiControllerBase(ICrudAppService<TKey, TEntityDto, TEntityAddDto, TEntityUpdateDto, TEntityQueryIntputDto, TEntityPageQueryInputDto> appService)
        {
            this.appService = appService;
        }

        [HttpGet("~/api/[controller]:paged")]
        public IPagedResult<TEntityDto> GetPagedList([FromQuery] TEntityPageQueryInputDto dto)
        {
            return appService.GetPagedList(dto);
        }

        [HttpGet]
        public IList<TEntityDto> GetList([FromQuery] TEntityQueryIntputDto dto)
        {
            return appService.GetList(dto);
        }

        [HttpGet("{id}")]
        public TEntityDto Get(TKey id,[FromQuery] string include)
        {
            return appService.Get(id,include);
        }

        [HttpPost]
        public TEntityDto Add([FromBody] TEntityAddDto dto)
        {
            return appService.Add(dto);
        }

        [HttpDelete("{id}")]
        public int Delete(TKey id)
        {
            return appService.Delete(id);
        }
        [HttpPatch("{id}")]
        public TEntityDto Update(TKey id, [FromBody] TEntityUpdateDto dto)
        {
            dto.Id = id;
            return appService.Update(dto);
        }
        [HttpPut]
        public TEntityDto Update([FromBody] TEntityUpdateDto dto)
        {
            return appService.Update(dto);
        }
    }
}
