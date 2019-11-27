using Comm100.Framework.AutoMapper;
using Comm100.Public.Constants;
using KB.Domain.Bo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KB.Application.Dto
{
    [AutoMapTo(typeof(ArticleUpdateBo))]
    public class ArticleUpdateDto
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(StringLength.MaxLength_ArticleTitle)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
