using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Comm100.Framework.AutoMapper;
using KB.Domain.Entities;

namespace KB.Application.Dto
{
    [AutoMapFrom(typeof(Article))]
    public class ArticleTagsDto
    {
        public IEnumerable<Guid> TagIds { get; set; }
    }
}
