using System;
using System.Collections.Generic;

namespace KB.Domain.Articles.Entity
{
    public enum EnumArticleStatus
    {
        Draft,
        Audited,
        Published,
    }
    public class Article
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public Guid AuthorId { get; set; }

        public Guid CategoryId { get; set; }
        
        public EnumArticleStatus Status { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        public void Publish()
        {
            if (this.Status != EnumArticleStatus.Audited)
            {
                throw new Exception("Article needs to be audited first.");
            }
            this.Status = EnumArticleStatus.Published;
        }

        public void Audit()
        {
            if (this.Status == EnumArticleStatus.Draft)
            {
                this.Status = EnumArticleStatus.Audited;
            }
        }
    }
}
