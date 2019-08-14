using Comm100.Public.Dto;
using KB.Application.Category;
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
