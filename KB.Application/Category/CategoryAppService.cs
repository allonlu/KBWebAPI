using KB.Domain.Categories.Service;
using KB.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Category
{
    public class CategoryAppService
    {
        private ICategoryDomainService _domainService;
        public CategoryAppService(ICategoryDomainService domainService)
        {
            this._domainService = domainService;
        }

        public void Delete(Guid id)
        {
            _domainService.Delete(id);
        }
    }
}
