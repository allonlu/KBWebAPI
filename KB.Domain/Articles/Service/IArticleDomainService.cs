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

        Tuple<int, IEnumerable<ArticleWithInclude>> GetList(ArticleQueryCondition condition);

        Article Add(Article entity);

        Article Update(Article entity);

        Article Delete(Guid id);

        void DeleteByCategory(Guid categoryId);

        void Publish(Guid articleId);

    }
}
