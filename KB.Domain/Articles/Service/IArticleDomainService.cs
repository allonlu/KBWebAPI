using Comm100.Framework;
using KB.Domain.Articles.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Domain.Services;

namespace KB.Domain.Articles.Service
{
    public interface IArticleDomainService : IDomainService
    {
        Article Get(Guid id);

        Article Get(Guid id, string include);

        int GetCount(ArticleQueryCondition condition);

        IEnumerable<Article> GetList(ArticleQueryCondition condition,
            string include, Sorting sorting, Paging paging);


        Article Add(Article entity);

        Article Update(Article entity);

        Article Delete(Guid id);

        void Delete(Article article);

        void Publish(Guid articleId);

    }
}
