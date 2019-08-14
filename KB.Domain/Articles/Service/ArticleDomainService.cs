using System;
using System.Collections.Generic;
using System.Linq;
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
        private IRepository<Guid, Category> _categoryRepository;
        public ArticleDomainService(IRepository<Guid, Article> repository,
            IRepository<Guid, Category> _categoryRepository)
        {
            this._repository = repository;
        }


        public Article Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Tuple<int, IEnumerable<ArticleWithInclude>> GetList(ArticleQueryCondition condition)
        {
            throw new NotImplementedException();
        }

        private void Delete(Article article)
        {
            IFeedbackDomainService feedbackDomainService = null; //IOC.Resolve<IFeedbackDomainService>();
            feedbackDomainService.DeleteByArticle(article.Id);

            ITagDomainService tagDomainService = null; // IOC.Resolve<ITagDomainService>();
            tagDomainService.DeleteByArticle(article.Id);

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

        public ArticleWithInclude Get(Guid id, string include)
        {
            throw new NotImplementedException();
        }

        
    }

    public class ArticleQueryCondition{
        public Guid? CategoryId { get; set; }

        public string Keywords { get; set; }

        public string Tag { get; set; }

        public Paging Paging { get; set; }

        public Sorting Sorting { get; set; }
    }

    public static class ArticleQueryExtension
    {
        public static IQueryable<Article> Query(this IQueryable<Article> query, ArticleQueryCondition condition)
        {
            return query
                .WhereIf(e => e.CategoryId == condition.CategoryId.Value, condition.CategoryId.HasValue)
                .WhereIf(e => e.Title.Contains(condition.Keywords) || e.Content.Contains(condition.Keywords), !string.IsNullOrEmpty(condition.Keywords))
                .WhereIf(e => e.Tags.Any(t => t == condition.Tag), !string.IsNullOrEmpty(condition.Tag));
                //
                //.Sorting()
                //.Paging(condition.Paging);
        }
    }
}
