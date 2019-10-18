using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Dto
{
    public class ArticleDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid CategoryId { get; set; }

        public Guid AuthorId { get; set; }

        public EnumArticleStatus Status { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        public IEnumerable<Guid> TagIds { get; set; }
    }
}
