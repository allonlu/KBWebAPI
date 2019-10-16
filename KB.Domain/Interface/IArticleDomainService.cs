using Comm100.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Domain.Services;
using KB.Domain.Entities;
using Comm100.Framework.Domain.Specifications;

namespace KB.Domain.Articles.Service
{
    public interface IArticleDomainService : IDomainService
    {
        Article Get(Guid id);
        int Count(BaseSpecification<Article> spec);

        IReadOnlyList<Article> List(BaseSpecification<Article> spec);

        Article Create(Article entity);

        Article Update(Article entity);

        Article Delete(Guid id);

        void Delete(Article article);

        void Publish(Guid articleId);
    }
}
