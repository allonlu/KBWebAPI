using Comm100.Framework;
using KB.Domain.Articles.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Articles.Service
{
    public interface IArticleDomainService
    {
        Article Get(Guid id);

        ArticleWithInclude Get(Guid id, string include);

        int GetCount(ArticleQueryCondition condition);

        IEnumerable<ArticleWithInclude> GetList(ArticleQueryCondition condition,
            string include, Sorting sorting, Paging paging);


        Article Add(Article entity);

        Article Update(Article entity);

        Article Delete(Guid id);

        void Delete(Article article);

        void Publish(Guid articleId);

    }
}
