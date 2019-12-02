using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework.AutoMapper;
using KB.Domain.Entities;

namespace KB.Application.Dto
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsPublished { get; set; }
    }
}
