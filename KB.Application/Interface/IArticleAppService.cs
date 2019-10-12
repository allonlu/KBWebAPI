using Comm100.Framework;
using KB.Application.Articles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Articles
{
    public interface IArticleAppService
    {
        ArticleWithIncludeDto Get(Guid id, string include);

        PagedListDto<ArticleWithIncludeDto> GetList(ArticleQueryDto dto, string include, Paging paging);

        ArticleDto Add(ArticleCreateDto dto);

        ArticleDto Update(ArticleUpdateDto dto);

        /*
         * On the interface of the DomainService, we returned the deleted article that we can do some auditing at the Application level.
         * But I full that I do't need to return this information to the client any more. In fact RESTful API will return NoContent to the client when delete an entity.
         */ 
        void Delete(Guid id);

        void PublishArticle(Guid id);
    }
}
