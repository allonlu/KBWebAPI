using Comm100.Framework.Domain.Specifications;
using KB.Domain.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
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
            : base(i => (!categoryId.HasValue || i.CategoryId == categoryId) &&
                 (tagId.HasValue || i.Tags.Any(t => t.TagId == tagId)) &&
                 (string.IsNullOrEmpty(keywords) || i.Content.Contains(keywords) || i.Title.Contains(keywords)))
        {
        }

        public void ApplyPaging(Paging paging)
        {
            base.ApplyPaging(paging.PageIndex, paging.PageSize);
        }
    }
}
