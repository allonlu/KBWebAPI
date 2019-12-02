using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Comm100.Framework.AutoMapper;

namespace KB.Domain.Entities
{
    [Table("t_KB_ArticleTag")]
    public class ArticleTag
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ArticleId { get; set; }

        [AutoMapKey]
        public Guid TagId { get; set; }
    }

    public class ArticleTagEqualityComparer : IEqualityComparer<ArticleTag>
    {
        public bool Equals(ArticleTag a1, ArticleTag a2)
        {
            if (a1 == null && a2 == null)
                return true;
            else if (a1 == null || a2 == null)
                return false;
            else if (a1.ArticleId == a2.ArticleId && a1.TagId == a2.TagId)
                return true;
            else
                return false;
        }

        public int GetHashCode(ArticleTag obj)
        {
            string hCode = obj.ArticleId.ToString() + obj.TagId.ToString();
            return hCode.GetHashCode();
        }
    }
}
