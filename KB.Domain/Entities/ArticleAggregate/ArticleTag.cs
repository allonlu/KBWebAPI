using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Entities
{
    public class ArticleTag
    {
        public Guid ArticleId { get; set; }

        public string Tag { get; set; }

    }
}
