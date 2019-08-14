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

        PagedListDto<ArticleWithIncludeDto> GetList(ArticleQueryDto dto);

        ArticleDto Add(ArticleCreateDto dto);

        ArticleDto Update(ArticleUpdateDto dto);

        void Delete(Guid id);

        void PublishArticle(Guid id);

        // Article Tags
        ArticleTagsDto GetTags(Guid id);

        ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto);

        ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto);

        ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto);
    }
}
