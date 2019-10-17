using Comm100.Framework;
using KB.Application.Dto;
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

        void Publish(Guid id);


        /*
         * @return {ArticleTagsDto} indicates all tags of the article, the following four interface are the same.
         * 
         * Note: We should avoid using arrays directly as passed arguments because it is very difficult to extend.
         *       Looking at Zendesk API, you can find that they never use arrays directly, they will wrap them around with an object.
         */
        ArticleTagsDto GetTags(Guid id);

        ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto);

        ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto);

        ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto);
    }
}
