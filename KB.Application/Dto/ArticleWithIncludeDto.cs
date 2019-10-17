using Comm100.Public.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Dto
{
    public class ArticleWithIncludeDto : ArticleDto
    {
        public AgentRefDto Author { get; set; }

        public CategoryRefDto Category { get; set; }
        
    }
}
