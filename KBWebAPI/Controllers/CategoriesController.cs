using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KB.Application.Dto;
using KB.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KBWebAPI.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryAppService _app;
        public CategoriesController(ICategoryAppService app)
        {
            this._app = app;
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> Get([FromRoute] Guid id)
        {
            CategoryDto category = _app.Get(id);
            return Ok(category);
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<CategoryDto>> GetList()
        {
            IReadOnlyList<CategoryDto> list = _app.GetList();
            return Ok(list);
        }

        [HttpPut]
        public ActionResult<CategoryDto> Put([FromBody] CategoryUpdateDto dto)
        {
            CategoryDto category = _app.Update(dto);
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<CategoryDto> Post([FromBody] CategoryCreateDto dto)
        {
            CategoryDto category = _app.Add(dto);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }
    }
}