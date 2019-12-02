using Comm100.Framework;
using Comm100.Framework.AutoMapper;
using Comm100.Public;
using Comm100.Public.Constants;
using KB.Domain.Bo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto
{
    [AutoMapTo(typeof(CategoryUpdateBo))]
    public class CategoryUpdateDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(StringLength.MaxLength_Name)]
        public string Name { get; set; }

        public Guid ParentId { get; set; }

        public bool IsPublished { get; set; }
    }
}
