using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KB.Domain.Entities
{
    [Table("t_KB_Tag")]
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
