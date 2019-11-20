using Comm100.Domain.Entity;
using Comm100.Framework.Domain.Entity;
using Comm100.Public;
using System;
using System.Collections.Generic;

namespace KB.Domain.Entities
{
    public enum ArticleStatus
    {
        draft,
        audited,
        published,
    }

    public class Article : ISoftDelete
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid AuthorId { get; set; }

        public Guid CategoryId { get; set; }

        public ArticleStatus Status { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        public virtual IEnumerable<ArticleTag> Tags { get; set; }

        public bool IsDeleted { get; set; }
    }
}
