using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Comm100.Framework;
using Comm100.Framework.Domain.Repository;
using KB.Domain.Articles.Entity;
using KB.Domain.Categories.Entity;
using KB.Domain.Service;

using KB.Domain.Tags;
using Comm100.Extension;

namespace KB.Domain.Articles.Service
{
    public class ArticleDomainService : IArticleDomainService
    {
        public ArticleDomainService(IRepository<Guid, Article> repository,
            //IRepository<Guid, ArticleWithInclude> repositoryWithInclude,
            IRepository<Guid, Category> categoryRepository)
        {
            this._repository = repository;
            //this._repositoryWithInclude = repositoryWithInclude;
            this._categoryRepository = categoryRepository;
        }


        public Article Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int GetCount(ArticleQueryCondition condition)
        {
            return this._repository.GetQuery()
                .Query(new ArticleQueryer() { Condition = condition })
                .Count();
        }

        public Article Get(Guid id, string include)
        {
            // TODO: need to solve the include
            return this._repository.Get(id);
        }

        public IEnumerable<Article> GetList(ArticleQueryCondition condition)
        {
            return this._repository.GetQuery()
                .Query(new ArticleQueryer() { Condition = condition })
                .ToList<Article>();
        }

        public IEnumerable<Article> GetList(ArticleQueryCondition condition, 
            string include, Sorting sorting, Paging paging)
        {
            return this._repository.GetQuery()
                    .Query(new ArticleQueryer() { Condition = condition })
                    .IncludeLoading(new ArticleInclude() { Include = include })
                    .Sorting(sorting)
                    .Paging(paging)
                    .ToList<Article>();
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
            _repository.Update(article);
        }
    }

    public struct ArticleFilter
    {
        public Guid? CategoryId { get; set; }

        public string Keywords { get; set; }

        public string Tag { get; set; }
    }

    public class ArticleQueryer : IEntityQueryer<Article>
    {
        public ArticleFilter Filter { get; set; }

        public IQueryable<Article> ProcessQuery(IQueryable<Article> query)
        {
            return query
                .WhereIf(e => e.CategoryId == Filter.CategoryId.Value, Filter.CategoryId.HasValue)
                .WhereIf(e => e.Title.Contains(Filter.Keywords) || e.Content.Contains(Filter.Keywords), !string.IsNullOrEmpty(Condition.Keywords));
                //.WhereIf(e => e.Tags.Any(t => t.Tag == Condition.Tag), !string.IsNullOrEmpty(Condition.Tag));
        }
    }


    public class ArticleInclude : IEntityIncluder<Article>
    {
        public string Include { get; set; }

        public IQueryable<Article> ProcessInclude(IQueryable<Article> query)
        {
            foreach (string name in Include.AnalyzeInclude())
            {
                switch(name)
                {
                    case "category":
                        query = query.Include(e => e.Category);
                        break;
                    case "author":
                        query = query.Include(e => e.Author);
                        break;
                    case "tags":
                        query = query.Include(e => e.Tags);
                        break;
                }
            }
            return query;
        }

        public Article ProcessInclude(Article t)
        {
            throw new NotImplementedException();
        }
    }
}
