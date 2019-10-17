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
        public ArticleFilterSpecification(Guid? categoryId, string tag, string keywords)
            : base(i => (!categoryId.HasValue || i.CategoryId == categoryId) &&
                 (string.IsNullOrEmpty(tag) || i.Tags.Any(t => t.Tag == tag)) &&
                 (string.IsNullOrEmpty(keywords) || i.Content.Contains(keywords) || i.Title.Contains(keywords)))
        {
        }

        public void ApplyPaging(Paging paging)
        {
            base.ApplyPaging(paging.PageIndex, paging.PageSize);
        }
    }
}
