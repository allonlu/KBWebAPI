using System.Collections.Generic;
using System.Text;
using Comm100.Framework.AutoMapper;
using Comm100.Public.Account.Dto;
using KB.Domain.Entities;

namespace KB.Application.Dto
{
    [AutoMapFrom(typeof(Article))]
    public class ArticleWithIncludeDto : ArticleDto
    {
        public AgentRefDto Author { get; set; }

        public CategoryRefDto Category { get; set; }

        public IEnumerable<TagRefDto> Tags { get; set; }
        
    }
}
