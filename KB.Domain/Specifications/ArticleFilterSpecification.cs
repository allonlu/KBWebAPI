using Comm100.Framework.Domain.Specifications;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Specifications
{
    public class ArticleFilterSpecification : BaseSpecification<Article>
    {
        public ArticleFilterSpecification(Guid categoryId)
            :base (i => i.CategoryId == categoryId)
        {

        }
    }
}
