using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ParentId { get; set; }
    }
}
