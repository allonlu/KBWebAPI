using System;
using System.Collections.Generic;
using System.Linq;
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
        private IRepository<Guid, Article> _repository;

        public ArticleDomainService(IRepository<Guid, Article> repository)
        {
            this._repository = repository;
        }

        public Article Create(Article entity)
        {
            return _repository.Create(entity);
        }

        public int Count(ArticleFilterSpecification spec)
        {
            return _repository.Count(spec);
        }

        public IReadOnlyList<Article> List(ArticleFilterSpecification spec)
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

            ICategoryDomainService categoryDomainService = null; // IOCContainer.Resolve<ICategoryDomainService>();

            Category category = categoryDomainService.Get(article.CategoryId);

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

        public Article AddTags(Guid id, IEnumerable<string> tags)
        {
            Article article = _repository.Get(id);

            article.Tags = article.Tags
                    .Concat<ArticleTag>(tags.Select(name => new ArticleTag() { ArticleId = id, Tag = name }))
                    .Distinct();

            _repository.Update(article);

            return article;
        }

        public Article DeleteTags(Guid id, IEnumerable<string> tags)
        {
            Article article = _repository.Get(id);

            article.Tags = article.Tags.Where(tag => !tags.Any(name => tag.Tag == name));

            _repository.Update(article);

            return article;

        }

        public Article SetTags(Guid id, IEnumerable<string> tags)
        {
            Article article = _repository.Get(id);

            article.Tags = tags.Select(name => new ArticleTag() { ArticleId = id, Tag = name });

            return article;
        }
    }
}
