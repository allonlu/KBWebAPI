using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Bo
{
    public class ArticleUpdateBo
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
