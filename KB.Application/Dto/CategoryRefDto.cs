﻿using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework.AutoMapper;
using KB.Domain.Entities;

namespace KB.Application.Dto
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryRefDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
