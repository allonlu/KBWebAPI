using Comm100.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Articles.Dto
{
    public class ArticleCreateDto
    {

        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(StringLength.MaxTitleLength)]
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid AuthorId { get; set; }

        // public IEnumerable<string> Tags { get; set; }

    }
}
