using KB.Application.Articles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Articles
{
    public interface IArticleTagsAppService
    {

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
