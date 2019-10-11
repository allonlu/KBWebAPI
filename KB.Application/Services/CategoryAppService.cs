using AutoMapper;
using Comm100.Application.Services;
using KB.Application.Categories.Dto;
using KB.Domain.Categories.Service;
using KB.Domain.Entities;
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

        public void Delete(Guid id)
        {
            _domainService.Delete(id);
        }

        public CategoryDto Add(CategoryCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
