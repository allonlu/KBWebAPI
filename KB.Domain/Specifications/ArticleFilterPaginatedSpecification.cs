using Comm100.Framework.Domain.Specifications;
using KB.Domain.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework;

namespace KB.Domain.Specificaitons
{
    public class ArticleFilterPaginatedSpecification : BaseSpecification<Article>
    {
        public ArticleFilterPaginatedSpecification(Guid? categoryId, string tag, string keywords, Paging paging)
            :base(i => (!categoryId.HasValue || i.CategoryId == categoryId) &&
                (!string.IsNullOrEmpty(tag) || i.Tags.Any(t => t.Tag == tag)))
        {
            ApplyPaging(paging.PageIndex, paging.PageSize);
        }
    }
}
