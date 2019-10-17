using Comm100.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto
{
    public class CategoryUpdateDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(StringLength.MaxNameLength)]
        public string Name { get; set; }

        public Guid ParentId { get; set; }

        public bool IsPublished { get; set; }
    }
}
