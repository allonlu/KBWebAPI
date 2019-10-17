using Comm100.Framework.Domain.Specifications;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Specifications
{
    public class CategoryFilterSpecification : BaseSpecification<Category>
    {
        public CategoryFilterSpecification(Guid parentId)
            :base(c => c.ParentId == parentId)
        {
        }
    }
}
