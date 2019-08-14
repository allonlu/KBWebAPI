using KB.Domain.Articles.Entity;
using KB.Domain.Articles.Service;
using KB.Domain.Categories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KB.Domain.Categories.Service
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly IRepository<Guid, Category> _repository;
        public CategoryDomainService(IRepository<Guid, Category> repository)
        {
            this._repository = repository;
        }

        public void DeleteAndAdoptChildren(Guid id, Guid targetId)
        {
            Category category = _repository.Get(id);
            IList<Category> childrenCategory = _repository.GetQuery(c => c.ParentId == id).ToList<Category>();

            // _repository.Update(c => c.ParentId == id, new { ParentId = targetId }); // bulk update

            foreach(var child in childrenCategory)
            {
                child.ParentId = targetId;
                _repository.Update(child);
            }

            _repository.Delete(category);
        }

        public void Delete(Guid id)
        {
            Category category = _repository.Get(id);

            IList<Category> children = _repository.GetQuery(c => c.ParentId == id).ToList<Category>();

            foreach(var child in children)
            {
                Delete(child.Id);
            }

            IArticleDomainService _articleDomainService = null; //IOC.Resolve<IArticleDomainService>();
            _articleDomainService.DeleteByCategory(id);

            _repository.Delete(category);

        }
        
    }
}
