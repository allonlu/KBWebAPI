using System;
using System.Linq;
using Comm100.Framework.Domain.Repository;
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KB.Domain.Articles.Service
{
    public class ArticleDomainService : IArticleDomainService
    {
        private IRepository<Guid, Category> _categoryRepository;
        public ArticleDomainService(IRepository<Guid, Category> categoryRepository)
        {
            this._categoryRepository = categoryRepository;
            IQueryable<Article> q = null;
            q.Include("");
        }

        public void Publish(Article article)
        {
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
    }

    //public struct ArticleFilter
    //{
    //    public Guid? CategoryId { get; set; }

    //    public string Keywords { get; set; }

    //    public string Tag { get; set; }
    //}

    //public class ArticleQueryer : IEntityQueryer<Article>
    //{
    //    public ArticleFilter Filter { get; set; }

    //    public IQueryable<Article> ProcessQuery(IQueryable<Article> query)
    //    {
    //        return query
    //            .WhereIf(e => e.CategoryId == Filter.CategoryId.Value, Filter.CategoryId.HasValue)
    //            .WhereIf(e => e.Title.Contains(Filter.Keywords) || e.Content.Contains(Filter.Keywords), !string.IsNullOrEmpty(Condition.Keywords));
    //            //.WhereIf(e => e.Tags.Any(t => t.Tag == Condition.Tag), !string.IsNullOrEmpty(Condition.Tag));
    //    }
    //}


    //public class ArticleInclude : IEntityIncluder<Article>
    //{
    //    public string Include { get; set; }

    //    public IQueryable<Article> ProcessInclude(IQueryable<Article> query)
    //    {
    //        foreach (string name in Include.AnalyzeInclude())
    //        {
    //            switch(name)
    //            {
    //                case "category":
    //                    query = query.Include(e => e.Category);
    //                    break;
    //                case "author":
    //                    query = query.Include(e => e.Author);
    //                    break;
    //                case "tags":
    //                    query = query.Include(e => e.Tags);
    //                    break;
    //            }
    //        }
    //        return query;
    //    }

    //    public Article ProcessInclude(Article t)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
