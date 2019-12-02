using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Comm100.Domain.Entity;

namespace KB.Domain.Entities
{
    [Table("t_KB_Category")]
    public class Category : IMultiSite
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsPublished { get; set; }

        public int SiteId { get; set; }
    }
}
