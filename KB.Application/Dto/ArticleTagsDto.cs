﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Dto
{
    public class ArticleTagsDto
    {
        public IEnumerable<Guid> TagIds { get; set; }
    }
}
