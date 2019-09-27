using Comm100.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Articles.Dto
{
    public class ArticleUpdateDto
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(StringLength.MaxTitleLength)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
