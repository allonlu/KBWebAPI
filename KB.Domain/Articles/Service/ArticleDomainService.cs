using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Comm100.Framework;
using KB.Domain.Articles.Entity;
using KB.Domain.Categories.Entity;
using KB.Domain.Service;
using KB.Domain.Tags;

namespace KB.Domain.Articles.Service
{
    public class ArticleDomainService : IArticleDomainService
    {
        private IRepository<Guid, Article> _repository;
        private IRepository<Guid, ArticleWithInclude> _repositoryWithInclude;
        private IRepository<Guid, Category> _categoryRepository;

        public ArticleDomainService(IRepository<Guid, Article> repository,
            IRepository<Guid, ArticleWithInclude> repositoryWithInclude,
            IRepository<Guid, Category> categoryRepository)
        {
            this._repository = repository;
            this._repositoryWithInclude = repositoryWithInclude;
            this._categoryRepository = categoryRepository;
        }


        public Article Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int GetCount(ArticleQueryCondition condition)
        {
            return this._repository.GetQuery()
                .Query(new ArticleQueryer<Article>() { Condition = condition })
                .Count();
        }

        public ArticleWithInclude Get(Guid id, string include)
        {
            // TODO: need to solve the include
            return this._repositoryWithInclude.Get(id);
        }

        public IEnumerable<Article> GetList(ArticleQueryCondition condition)
        {
            return this._repository.GetQuery()
                .Query(new ArticleQueryer<Article>() { Condition = condition })
                .ToList<Article>();
        }

        public IEnumerable<ArticleWithInclude> GetList(ArticleQueryCondition condition, 
            string include, Sorting sorting, Paging paging)
        {
            return this._repositoryWithInclude.GetQuery()
                    .Query(new ArticleQueryer<ArticleWithInclude>() { Condition = condition })
                    .IncludeLoading(new ArticleInclude() { Include = include })
                    .Sorting(sorting)
                    .Paging(paging)
                    .ToList<ArticleWithInclude>();
        }

        public void Delete(Article article)
        {
            IFeedbackDomainService feedbackDomainService = null; //IOC.Resolve<IFeedbackDomainService>();
            feedbackDomainService.DeleteByArticle(article.Id);

            IArticleTagsDomainService articleTagDomainService = null; // IOC.Resolve<ITagDomainService>();
            articleTagDomainService.Delete(article.Id);

            _repository.Delete(article);
        }


        public Article Add(Article entity)
        {
            throw new NotImplementedException();
        }

        public Article Update(Article entity)
        {
            throw new NotImplementedException();
        }

        public Article Delete(Guid id)
        {
            Article article = _repository.Get(id);
            Delete(article);
            return article;
        }

        public void DeleteByCategory(Guid categoryId)
        {
            IList<Article> articles = _repository.GetQuery(a => a.CategoryId == categoryId).ToList<Article>();

            foreach (var article in articles)
            {
                Delete(article);
            }
        }

        public void Publish(Guid id)
        {
            Article article = _repository.Get(id);
            Category category = _categoryRepository.Get(article.CategoryId);
            if (category.isPublished)
            {
                article.Publish();
            }
            else
            {
                throw new Exception("You can only publish article below the public category.");
            }
            _repository.Update(article);
        }

        
    }

    public class ArticleQueryCondition
    {
        public Guid? CategoryId { get; set; }

        public string Keywords { get; set; }

        public string Tag { get; set; }
    }

    public class ArticleQueryer<T> : IEntityQueryer<T> where T : Article
    {
        public ArticleQueryCondition Condition { get; set; }

        public IQueryable<T> ProcessQuery(IQueryable<T> query)
        {
            return query
                .WhereIf(e => e.CategoryId == Condition.CategoryId.Value, Condition.CategoryId.HasValue)
                .WhereIf(e => e.Title.Contains(Condition.Keywords) || e.Content.Contains(Condition.Keywords), !string.IsNullOrEmpty(Condition.Keywords))
                .WhereIf(e => e.Tags.Any(t => t == Condition.Tag), !string.IsNullOrEmpty(Condition.Tag));
        }
    }


    public class ArticleInclude : IEntityIncluder<ArticleWithInclude>
    {
        public string Include { get; set; }

        public IQueryable<ArticleWithInclude> ProcessInclude(IQueryable<ArticleWithInclude> query)
        {
            foreach (string name in Include.AnalyzeInclude())
            {
                switch(name)
                {
                    case "author":
                        return query.Include(e => e.Author);
                }
            }
            return null;
        }

        public ArticleWithInclude ProcessInclude(ArticleWithInclude t)
        {
            return t;
        }
    }
}
