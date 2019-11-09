using Comm100.Public.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto
{
    public class ArticleUpdateDto
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(StringLength.MaxLength_ArticleTitle)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
