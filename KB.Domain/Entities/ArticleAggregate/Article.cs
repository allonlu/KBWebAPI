using Comm100.Domain.Entity;
using Comm100.Framework.Constants;
using Comm100.Framework.Domain.Entity;
using Comm100.Framework.Extension;
using Comm100.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace KB.Domain.Entities
{
    public enum ArticleStatus
    {
        DRAFT,
        AUDITED,
        PUBLISHED,
    }

    [TableSeparate("t_KB_Article")]
    public class Article : ISoftDelete
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid AuthorId { get; set; }

        public Guid CategoryId { get; set; }

        [EnumToString]
        public ArticleStatus Status { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        [ForeignKey("ArticleId")]
        public virtual ICollection<ArticleTag> Tags { get; set; }

        public bool IsDeleted { get; set; }
    }
}
