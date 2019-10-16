using KB.Domain.Articles.Service;
using Comm100.Framework.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KB.Domain.Entities;
using KB.Domain.Specifications;
using KB.Domain.Specificaitons;

namespace KB.Domain.Categories.Service
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly IRepository<Guid, Category> _repository;
        private readonly IRepository<Guid, Article> _articleRepository;
        public CategoryDomainService(IRepository<Guid, Category> repository, 
            IRepository<Guid, Article> articleRepository)
        {
            this._repository = repository;
            this._articleRepository = articleRepository;
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

            var articles = _articleRepository.List(new ArticleFilterSpecification(id, null, null));

            foreach (var article in articles)
            {
                article.CategoryId = targetId;
                _articleRepository.Update(article);
            }

            _repository.Delete(category);
        }

        public void Delete(Guid id)
        {
            Category category = _repository.Get(id);

            var children = _repository.List(new CategoryFilterSpecification(id));

            foreach(var child in children)
            {
                Delete(child.Id);
            }

            var articles = _articleRepository.List(new ArticleFilterSpecification(id, null, null));

            foreach (var article in articles)
            {
                _articleRepository.Delete(article);
            }
            _repository.Delete(category);

        }
        
    }
}
