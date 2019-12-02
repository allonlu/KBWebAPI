using Comm100.Domain.Entity;
using Comm100.Framework.Constants;
using Comm100.Framework.Domain.Entity;
using Comm100.Framework.Extension;
using Comm100.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KB.Domain.Entities
{
    public enum ArticleStatus
    {
        DRAFT,
        AUDITED,
        PUBLISHED,
    }

    [Table("t_KB_Article" + DBConstants.MULTI_TENANT_TABLE_PLACEHOLDER)]
    public class Article : ISoftDelete
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid AuthorId { get; set; }

        public Guid CategoryId { get; set; }

        [Column("Status")]
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = value.ParseEnum<ArticleStatus>();  }
        }

        [NotMapped]
        public ArticleStatus Status { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        [ForeignKey("ArticleId")]
        public virtual ICollection<ArticleTag> Tags { get; set; }

        public bool IsDeleted { get; set; }
    }
}
