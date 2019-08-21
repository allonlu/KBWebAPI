using Comm100.Public;
using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework;
using System.Linq;
using KB.Domain.Categories.Entity;

namespace KB.Domain.Articles.Entity
{
    public class ArticleWithInclude : Article
    {
        public virtual Category Category { get; set; }
        public virtual Agent Author { get; set; }
    }
}
