using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Bo
{
    public class CategoryUpdateBo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ParentId { get; set; }
    }
}
