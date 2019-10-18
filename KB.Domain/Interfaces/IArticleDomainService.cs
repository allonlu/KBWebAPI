using Comm100.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Domain.Services;
using KB.Domain.Entities;
using Comm100.Framework.Domain.Specifications;
using KB.Domain.Bo;
using KB.Domain.Specificaitons;

namespace KB.Domain.Interfaces
{
    public interface IArticleDomainService : IDomainService
    {
        Article Get(Guid id);

        int Count(ArticleFilterSpecification spec);

        IReadOnlyList<Article> List(ArticleFilterSpecification spec);

        Article Create(Article entity);

        Article Update(ArticleUpdateBo entity);

        Article Delete(Guid id);

        void Publish(Guid articleId);

        Article AddTags(Guid id, IEnumerable<Guid> tagIds);

        Article DeleteTags(Guid id, IEnumerable<Guid> tagIds);

        Article SetTags(Guid id, IEnumerable<Guid> tagIds);
    }
}
