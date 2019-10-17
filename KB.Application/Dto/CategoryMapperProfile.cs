using AutoMapper;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Dto
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryRefDto>();
        }
    }
}
