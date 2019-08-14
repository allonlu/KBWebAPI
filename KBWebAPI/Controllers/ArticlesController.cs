using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comm100.Framework;
using KB.Application.Articles;
using KB.Application.Articles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KBWebAPI.Controllers
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
        public ActionResult<ArticleWithIncludeDto> Get(Guid id, string include)
        {
            var article = _app.Get(id, include);
            return Ok(article);
        }

        [HttpGet]
        public ActionResult<PagedListDto<ArticleWithIncludeDto>> GetList([FromQuery] ArticleQueryDto dto, [FromBody] Paging paging)
        {
            var list = _app.GetList(dto);
            return Ok(list);
        }

        [HttpPost]
        public ActionResult<ArticleDto> Post(ArticleCreateDto dto)
        {
            var article = _app.Add(dto);
            return CreatedAtAction(nameof(Get), new { id = article.Id }, article);
        }

        [HttpPut("{id}")]
        public ActionResult<ArticleDto> Put(Guid id, ArticleUpdateDto dto)
        {
            var article = _app.Update(dto);
            return Ok(article);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _app.Delete(id);
            return NoContent();
        }

        [HttpPost("{id}:publish")]
        public ActionResult<ArticleDto> Publish(Guid id)
        {
            _app.PublishArticle(id);
            return Ok();
        }

        // tags
        [HttpGet("{id}/tags")]
        public ActionResult<ArticleTagsDto> GetTags(Guid id)
        {
            var tags = _app.GetTags(id);
            return Ok(tags);
        }

        [HttpPost("{id}/tags")]
        public ActionResult<ArticleTagsDto> AddTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _app.AddTags(id, dto);
            return Ok(tags);
        }

        [HttpPut("{id}/tags")]
        public ActionResult<ArticleTagsDto> SetTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _app.SetTags(id, dto);
            return Ok(tags);
        }

        [HttpDelete("{id}/tags")]
        public ActionResult<ArticleTagsDto> DeleteTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _app.DeleteTags(id, dto);
            return Ok(tags);
        }
    }
}
