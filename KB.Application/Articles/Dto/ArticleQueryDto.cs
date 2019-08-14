using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Articles.Dto
{
    public class ArticleQueryDto
    {
        public Guid? CategoryId { get; set; }
        public string Keywords { get; set; }
        public string Tag { get; set; }
    }
}
