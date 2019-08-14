using Comm100.Public;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Articles.Entity
{
    public class ArticleWithInclude : Article
    {
        public virtual Agent Author { get; set; }
    }
}
