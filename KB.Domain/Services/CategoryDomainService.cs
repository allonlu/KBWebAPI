using Comm100.Framework.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KB.Domain.Entities;
using KB.Domain.Specifications;
using KB.Domain.Specificaitons;
using KB.Domain.Interfaces;
using KB.Domain.Bo;
using Castle.Windsor;

namespace KB.Domain.Categories.Service
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private IWindsorContainer _container;
        private readonly IRepository<Guid, Category> _repository;

        public CategoryDomainService(IRepository<Guid, Category> repository, IWindsorContainer container)
        {
            this._repository = repository;
            this._container = container;
        }

        public Category Create(Category category)
        {
            return _repository.Create(category);
        }

        public Category Get(Guid id)
        {
            return _repository.Get(id);
        }

        public Category Update(CategoryUpdateBo bo)
        {
            Category category = _repository.Get(bo.Id);

            category.Name = bo.Name;

            if (Guid.Empty == bo.ParentId || _repository.Exists(bo.ParentId))
            {
                category.ParentId = bo.ParentId;
            }
            else
            {
                throw new Exception($"Category with Id '{bo.ParentId}' is not exists.");
            }

            return category;

        }

        public IReadOnlyList<Category> List()
        {
            return _repository.ListAll();
        }

        public void DeleteAndAdoptChildren(Guid id, Guid targetId)
        {
            Category category = _repository.Get(id);

            var childrenCategory = _repository.List(new CategoryFilterSpecification(id));

            foreach (var child in childrenCategory)
            {
                child.ParentId = targetId;
                _repository.Update(child);
            }

            // maybe have performance issue for cascading delete
            IArticleDomainService articleDomainService = _container.Resolve<IArticleDomainService>();

            var articles = articleDomainService.List(new ArticleFilterSpecification(id));

            foreach (var article in articles)
            {
                articleDomainService.Update(new ArticleUpdateBo() { CategoryId = article.CategoryId });
            }

            _repository.Delete(category);
        }

        public void Delete(Guid id)
        {
            Category category = _repository.Get(id);

            var children = _repository.List(new CategoryFilterSpecification(id));

            foreach (var child in children)
            {
                Delete(child.Id);
            }

            IArticleDomainService articleDomainService = _container.Resolve<IArticleDomainService>();

            var articles = articleDomainService.List(new ArticleFilterSpecification(id, null, null));

            foreach (var article in articles)
            {
                articleDomainService.Delete(article.Id);
            }
            _repository.Delete(category);

        }
    }
}
