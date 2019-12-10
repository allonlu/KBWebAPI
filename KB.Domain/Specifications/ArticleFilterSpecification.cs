using Comm100.Framework.Domain.Specifications;
using KB.Domain.Entities;
using System.Linq;
using System;
using Comm100.Framework;

namespace KB.Domain.Specificaitons
{
    public class ArticleFilterSpecification : BaseSpecification<Article>
    {

        public ArticleFilterSpecification(Guid categoryId)
            : base(i => i.CategoryId == categoryId)
        {

        }

        public ArticleFilterSpecification(Guid? categoryId, Guid? tagId, string keywords)
            : base(article =>
                (!categoryId.HasValue || article.CategoryId == categoryId) &&
                (tagId.HasValue || article.Tags.Any(t => t.TagId == tagId)) &&
                (string.IsNullOrEmpty(keywords) || article.Content.Contains(keywords) || article.Title.Contains(keywords)))
        {
        }

        public void ApplyPaging(Paging paging)
        {
            base.ApplyPaging(paging.PageIndex, paging.PageSize);
        }
    }
}
