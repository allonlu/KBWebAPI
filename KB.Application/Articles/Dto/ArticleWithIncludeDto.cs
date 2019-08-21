using Comm100.Public.Dto;
using KB.Application.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Articles.Dto
{
    public class ArticleWithIncludeDto : ArticleDto
    {
        public AgentDto Author { get; set; }

        public CategoryDto Category { get; set; }
    }
}
