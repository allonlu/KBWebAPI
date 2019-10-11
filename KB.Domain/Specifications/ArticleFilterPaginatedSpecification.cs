using Comm100.Framework.Domain.Specifications;
using KB.Domain.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain
{
    public class ArticleFilterPaginatedSpecification : BaseSpecification<Article>
    {
        public ArticleFilterPaginatedSpecification(Guid? categoryId, string tag, string keywords)
            :base(i => (!categoryId.HasValue || i.CategoryId == categoryId) &&
                (!string.IsNullOrEmpty(tag) || i.Tags.Any(t => t.Tag == tag))
        {

        }
    }
}
