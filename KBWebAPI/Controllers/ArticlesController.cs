using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comm100.Framework;
using KB.Application.Articles;
using KB.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        private readonly IArticleAppService _app;

        public ArticlesController(IArticleAppService app)
        {
            this._app = app;
        }

        [HttpGet("{id}")]
        public ActionResult<ArticleWithIncludeDto> Get([FromRoute] Guid id, [FromQuery] string include)
        {
            var article = _app.Get(id, include);
            return Ok(article);
        }

        [HttpGet]
        public ActionResult<PagedListDto<ArticleWithIncludeDto> > GetList([FromQuery] ArticleQueryDto dto, 
            [FromQuery] string include, [FromQuery] Paging paging)
        {
            PagedListDto<ArticleWithIncludeDto> list =  _app.GetList(dto, include, paging);
            return Ok(list);
        }

        [HttpPost]
        public ActionResult<ArticleDto> Post([FromBody] ArticleCreateDto dto)
        {
            var article = _app.Add(dto);
            return CreatedAtAction(nameof(Get), new { id = article.Id }, article);
        }

        [HttpPut("{id}")]
        public ActionResult<ArticleDto> Put([FromRoute] Guid id, [FromBody]ArticleUpdateDto dto)
        {
            var article = _app.Update(dto);
            return Ok(article);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _app.Delete(id);
            return NoContent();
        }

        public IActionResult Delete([FromBody] Guid[] ids)
        {
            return NoContent();
        }

        [HttpPost("{id}:publish")]
        public ActionResult<ArticleDto> Publish([FromRoute] Guid id)
        {
            _app.Publish(id);
            return Ok();
        }

        // tags
        [HttpGet("{id}/tags")]
        public ActionResult<ArticleTagsDto> GetTags([FromRoute] Guid id)
        {
            var tags = _app.GetTags(id);
            return Ok(tags);
        }

        [HttpPost("{id}/tags")]
        public ActionResult<ArticleTagsDto> AddTags([FromRoute] Guid id, [FromBody] ArticleTagsDto dto)
        {
            var tags = _app.AddTags(id, dto);
            return Ok(tags);
        }

        [HttpPut("{id}/tags")]
        public ActionResult<ArticleTagsDto> SetTags([FromRoute] Guid id, [FromBody] ArticleTagsDto dto)
        {
            var tags = _app.SetTags(id, dto);
            return Ok(tags);
        }

        [HttpDelete("{id}/tags")]
        public ActionResult<ArticleTagsDto> DeleteTags([FromRoute] Guid id, [FromBody] ArticleTagsDto dto)
        {
            var tags = _app.DeleteTags(id, dto);
            return Ok(tags);
        }

        [HttpPost(":import")]
        public IActionResult Import()//File file)
        {
            // convert xml file to object
            // validate object
            //_app.Import(articles) // async
            return NoContent();
        }
    }
}
