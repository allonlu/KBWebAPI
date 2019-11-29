using AutoMapper;
using Comm100.Application.Services;
using Comm100.Framework.Auditing;
using Comm100.Framework.Authorization;
using Comm100.Public.Audit;
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
        }

        [Authorization(KBPermission.CATEGORY, AuthorizationType.WRITE)]
        [Authorization(KBPermission.ARTICLE, AuthorizationType.WRITE)]
        [Audit(KBEntity.CATEGORY, AuditAction.DESTROY)]
        public void Delete(Guid id)
        {
            _domainService.Delete(id);
        }

        [Authorization(KBPermission.CATEGORY, AuthorizationType.WRITE)]
        [Audit(KBEntity.CATEGORY, AuditAction.CREATE)]
        public CategoryDto Add(CategoryCreateDto dto)
        {
            Category category = _domainService.Create(Mapper.Map<Category>(dto));
            return Mapper.Map<CategoryDto>(category);
        }

        [Authorization(KBPermission.CATEGORY, AuthorizationType.WRITE)]
        [Audit(KBEntity.CATEGORY, AuditAction.UPDATE)]
        public CategoryDto Update(CategoryUpdateDto dto)
        {
            Category category = _domainService.Update(Mapper.Map<CategoryUpdateBo>(dto));
            return Mapper.Map<CategoryDto>(category);
        }

        [Authorization(KBPermission.CATEGORY, AuthorizationType.READ)]
        public CategoryDto Get(Guid id)
        {
            Category category = _domainService.Get(id);
            return Mapper.Map<CategoryDto>(category);
        }

        [Authorization(KBPermission.CATEGORY, AuthorizationType.READ)]
        public IEnumerable<CategoryDto> GetList()
        {
            IEnumerable<Category> list = _domainService.List();
            return Mapper.Map<IEnumerable<CategoryDto>>(list);
        }
    }
}
