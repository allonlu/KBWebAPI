using Comm100.Public;
using KB.Domain.Categories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Articles.Entity
{
    public class ArticleWithInclude : Article
    {
        public virtual Category Category { get; set; }

        public virtual Agent Author { get; set; }
    }
}
