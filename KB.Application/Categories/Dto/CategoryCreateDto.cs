using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Categories.Dto
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }

        public Guid ParentId { get; set; }
    }
}
