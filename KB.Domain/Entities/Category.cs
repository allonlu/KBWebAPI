using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ParentId { get; set; }

        public bool IsPublished { get; set; }
    }
}
