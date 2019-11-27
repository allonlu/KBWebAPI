using System;
using System.Collections.Generic;
using KB.Domain.Entities;
using KB.Domain.Bo;
using KB.Domain.Specificaitons;
using Comm100.Framework.Domain.Services;

namespace KB.Domain.Interfaces
{
    public interface IArticleDomainService : IDomainService
    {
        Article Get(Guid id);

        int Count(ArticleFilterSpecification spec);

        IEnumerable<Article> List(ArticleFilterSpecification spec);

        Article Create(Article entity);

        Article Update(ArticleUpdateBo entity);

        Article Delete(Guid id);

        void Publish(Guid articleId);

        Article AddTags(Guid id, IEnumerable<Guid> tagIds);

        Article DeleteTags(Guid id, IEnumerable<Guid> tagIds);

        Article SetTags(Guid id, IEnumerable<Guid> tagIds);
    }
}
