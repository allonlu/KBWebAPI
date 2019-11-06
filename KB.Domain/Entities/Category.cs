using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Domain.Entity;

namespace KB.Domain.Entities
{
    public class Category : IMultiSite
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsPublished { get; set; }

        public int SiteId { get; set; }
    }
}
