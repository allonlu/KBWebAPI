using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Comm100.Framework.Domain.Repository;
using Comm100.Framework.Domain.Specifications;
using KB.Domain.Bo;
using KB.Domain.Entities;
using KB.Domain.Interfaces;
using KB.Domain.Specificaitons;

namespace KB.Domain.Services
{
    public class ArticleDomainService : IArticleDomainService
    {
        private IWindsorContainer _container;

        private IRepository<Guid, Article> _repository;

        public ArticleDomainService(IRepository<Guid, Article> repository, IWindsorContainer container)
        {
            this._repository = repository;
            this._container = container;
        }

        public Article Create(Article entity)
        {
            return _repository.Create(entity);
        }

        public int Count(ArticleFilterSpecification spec)
        {
            return _repository.Count(spec);
        }

        public IEnumerable<Article> List(ArticleFilterSpecification spec)
        {
            return _repository.List(spec);
        }

        public Article Delete(Guid id)
        {
            Article article = _repository.Get(id);

            if (article != null)
            {
                _repository.Delete(article);
            }

            return article;
        }

        public Article Get(Guid id)
        {
            Article article = _repository.Get(id);

            if (article == null)
            {
                throw new Exception($"Article with Id '{id}' does not exist.");
            }

            return article;
        }

        public void Publish(Guid articleId)
        {
            Article article = _repository.Get(articleId);

            ICategoryDomainService categoryDomainService = _container.Resolve<ICategoryDomainService>();

            Category category = categoryDomainService.Get(article.CategoryId);

            if (category.IsPublished)
            {
                if (article.Status != ArticleStatus.AUDITED)
                {
                    throw new Exception("Article needs to be audited first.");
                }
                article.Status = ArticleStatus.PUBLISHED;
            }
            else
            {
                throw new Exception("You can only publish article below the public category.");
            }
        }

        public Article Update(ArticleUpdateBo bo)
        {
            Article article = _repository.Get(bo.Id);

            // Check title unique

            article.Title = bo.Title;       // here can use auto-mapper to update if there are many fields
            article.Content = bo.Content;

            // update other system fields like lastModifiedTime

            _repository.Update(article);
            return article;
        }

        public Article AddTags(Guid id, IEnumerable<Guid> tagIds)
        {
            Article article = _repository.Get(id);

            IEnumerable<ArticleTag> addingTags = tagIds.Select(tagId => new ArticleTag() { ArticleId = id, TagId = tagId });

            ArticleTagEqualityComparer comparer = new ArticleTagEqualityComparer();

            foreach (ArticleTag addingTag in addingTags)
            {
                if (!article.Tags.Contains(addingTag, comparer))
                {
                    article.Tags.Add(addingTag);
                }
            }

            _repository.Update(article);

            return article;
        }

        public Article DeleteTags(Guid id, IEnumerable<Guid> tagIds)
        {
            Article article = _repository.Get(id);

            IEnumerable<ArticleTag> removingTags = tagIds.Select(tagId => new ArticleTag() { ArticleId = id, TagId = tagId });

            ArticleTagEqualityComparer comparer = new ArticleTagEqualityComparer();

            foreach (ArticleTag tag in article.Tags)
            {
                if (removingTags.Contains(tag, comparer))
                {
                    article.Tags.Remove(tag);
                }
            }

            _repository.Update(article);

            return article;

        }

        public Article SetTags(Guid id, IEnumerable<Guid> tagIds)
        {
            Article article = _repository.Get(id);

            article.Tags = tagIds.Select(tagId => new ArticleTag() { ArticleId = id, TagId = tagId }).ToList();

            return article;
        }
    }
}
