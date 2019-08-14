using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Categories.Entity
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ParentId { get; set; }

        public bool isPublished { get; set; }
    }
}
