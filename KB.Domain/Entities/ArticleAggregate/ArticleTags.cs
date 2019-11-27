using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Articles.Entity
{
    public class ArticleTags
    {
        public virtual IEnumerable<ArticleTag> Tags { get; set; }
    }
}
