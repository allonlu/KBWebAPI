using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework.AutoMapper;
using KB.Domain.Entities;

namespace KB.Application.Dto
{
    [AutoMapTo(typeof(Category))]
    public class CategoryCreateDto
    {
        public string Name { get; set; }

        public Guid ParentId { get; set; }
    }
}
