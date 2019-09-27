using AutoMapper;
using KB.Domain.Categories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Categories.Dto
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryRefDto>();
        }
    }
}
