﻿using AutoMapper;
using Comm100.Application.Services;
using Comm100.Runtime;
using KB.Application.Dto;
using KB.Application.Services;
using KB.Domain.Bo;
using KB.Domain.Entities;
using KB.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Categories.Service
{
    public class CategoryAppService : AppServiceBase, ICategoryAppService
    {
        private ICategoryDomainService _domainService;

        public CategoryAppService(ICategoryDomainService domainService) : base()
        {
            this._domainService = domainService;
            var configuration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<Category, CategoryDto>();
            });
            this.Mapper = configuration.CreateMapper();
        }

        [Permission("category:write")]
        public void Delete(Guid id)
        {
            _domainService.Delete(id);
        }

        [Permission("category:write")]
        public CategoryDto Add(CategoryCreateDto dto)
        {
            Category category = _domainService.Create(Mapper.Map<Category>(dto));
            return Mapper.Map<CategoryDto>(category);
        }

        [Permission("category:write")]
        public CategoryDto Update(CategoryUpdateDto dto)
        {
            Category category = _domainService.Update(Mapper.Map<CategoryUpdateBo>(dto));
            return Mapper.Map<CategoryDto>(category);
        }

        [Permission("category:read")]
        public CategoryDto Get(Guid id)
        {
            Category category = _domainService.Get(id);
            return Mapper.Map<CategoryDto>(category);
        }

        [Permission("category:read")]
        public IReadOnlyList<CategoryDto> GetList()
        {
            IReadOnlyList<Category> list = _domainService.List();
            return Mapper.Map<IReadOnlyList<CategoryDto>>(list);
        }
    }
}
