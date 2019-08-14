using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Articles.Dto
{
    public class ArticleUpdateDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
