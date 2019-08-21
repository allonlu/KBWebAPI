using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Comm100.Framework;
using KB.Application.Articles.Dto;
using KB.Domain.Articles.Entity;
using KB.Domain.Articles.Service;
using Comm100.Runtime;
using Comm100.Application.Services;
using Comm100.Runtime.Transactions;

namespace KB.Application.Articles
{
    public class ArticleAppService : AppServiceBase, IArticleAppService
    {

        private readonly IArticleDomainService _articleDomainService;

        public override void OnMapperConfiguration(IProfileExpression config)
        {
            config.CreateMap<Article, ArticleDto>();
            config.CreateMap<ArticleWithInclude, ArticleWithIncludeDto>();

            config.CreateMap<ArticleCreateDto, Article>();
            config.CreateMap<ArticleQueryDto, ArticleQueryCondition>();
            config.CreateMap<ArticleTagsDto, ArticleTags>();
            config.CreateMap<ArticleTags, ArticleTagsDto>();
        }


        
        public ArticleAppService(IArticleDomainService articleDomainService) : base()
        {
            this._articleDomainService = articleDomainService;
        }

        [Permission("article:write")]
        [Transaction(System.Transactions.IsolationLevel.Serializable)]
        public ArticleDto Add(ArticleCreateDto dto)
        {
            var article = this._articleDomainService.Add(Mapper.Map<Article>(dto));
            return Mapper.Map<ArticleDto>(article);
        }

        [Permission("article.write")]
        public void PublishArticle(Guid id)
        {
            _articleDomainService.Publish(id);
        }

        [Permission("article.write")]
        public ArticleDto Update(ArticleUpdateDto dto)
        {
            var article = _articleDomainService.Get(dto.Id);
            Mapper.Map(dto, article);
            article = _articleDomainService.Update(article);
            return Mapper.Map<ArticleDto>(article);
        }

        [Permission("article.write")]
        public void Delete(Guid id)
        {
            var article = _articleDomainService.Delete(id);
            // audit log - article deleted
        }

        [Permission("article.read")]
        public ArticleWithIncludeDto Get(Guid id, string include)
        {
            var articleWithInclude = _articleDomainService.Get(id, include);
            return Mapper.Map<ArticleWithIncludeDto>(articleWithInclude);
        }

        [Permission("article.read")]
        public PagedListDto<ArticleWithIncludeDto> GetList(ArticleQueryDto dto, string include, Sorting sorting, Paging paging)
        {
            var condition = Mapper.Map<ArticleQueryCondition>(dto);
            var count = _articleDomainService.GetCount(condition);
            var list = _articleDomainService.GetList(condition, include, sorting, paging);
            return new PagedListDto<ArticleWithIncludeDto>(count, list.Select(e => Mapper.Map<ArticleWithIncludeDto>(e)));
        }

        
    }
}
