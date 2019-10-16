using System;
using System.Collections.Generic;
using System.Linq;
using Comm100.Framework.Domain.Repository;
using Comm100.Framework.Domain.Specifications;
using KB.Domain.Entities;
using KB.Domain.Specificaitons;
using Microsoft.EntityFrameworkCore;

namespace KB.Domain.Articles.Service
{
    public class ArticleDomainService : IArticleDomainService
    {
        private IRepository<Guid, Article> _articleRepository;
        private IRepository<Guid, Category> _categoryRepository;
        public ArticleDomainService(IRepository<Guid, Article> articleRepository, 
            IRepository<Guid, Category> categoryRepository)
        {
            this._articleRepository = articleRepository;
            this._categoryRepository = categoryRepository;
        }

        public Article Create(Article entity)
        {
            return _articleRepository.Create(entity);
        }

        public int Count(BaseSpecification<Article> spec)
        {
            return _articleRepository.Count(spec);
        }

        public IReadOnlyList<Article> List(BaseSpecification<Article> spec)
        {
            return _articleRepository.List(spec);
        }

        public Article Delete(Guid id)
        {
            Article article = _articleRepository.Get(id);
            _articleRepository.Delete(article);
            return article;
        }
        
        public void Delete(Article article)
        {
            _articleRepository.Delete(article);
        }

        public Article Get(Guid id)
        {
            return _articleRepository.Get(id);
        }

        public void Publish(Guid articleId)
        {
            Article article = _articleRepository.Get(articleId);
            Category category = _categoryRepository.Get(article.CategoryId);
            if (category.IsPublished)
            {
                if (article.Status != EnumArticleStatus.Audited.ToString())
                {
                    throw new Exception("Article needs to be audited first.");
                }
                article.Status = EnumArticleStatus.Published.ToString();
            }
            else
            {
                throw new Exception("You can only publish article below the public category.");
            }
        }

        public Article Update(Article entity)
        {
            _articleRepository.Update(entity);
            return entity;
        }
    }
}
