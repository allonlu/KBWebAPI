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
using System.Transactions;
using Comm100.Public.Dto;
using KB.Application.Categories.Dto;

namespace KB.Application.Articles
{
    public class ArticleAppService : AppServiceBase, IArticleAppService
    {

        private readonly IArticleDomainService _articleDomainService;

        public ArticleAppService(IArticleDomainService articleDomainService) : base()
        {
            this._articleDomainService = articleDomainService;

            MapperConfiguration configuration = new MapperConfiguration(config => {

                // because tags should be included, and if not include we should not return a empty array []
                config.AllowNullCollections = true; 

                config.AddProfile(new AgentMapperProfile());
                config.AddProfile(new CategoryMapperProfile());
                
                config.CreateMap<Article, ArticleDto>();
                config.CreateMap<Article, ArticleWithIncludeDto>();
                config.CreateMap<ArticleTag, string>().ConvertUsing(t => t.Tag);
         
                config.CreateMap<ArticleCreateDto, Article>();
                config.CreateMap<ArticleQueryDto, ArticleQueryCondition>();

                config.CreateMap<ArticleTagsDto, ArticleTags>();
                config.CreateMap<ArticleTags, ArticleTagsDto>();
            });

            this.Mapper = configuration.CreateMapper();
        }

        [Permission("article:write")]
        [Transaction(IsolationLevel.Serializable)]
        public ArticleDto Add(ArticleCreateDto dto)
        {
            Article article = this._articleDomainService.Add(Mapper.Map<Article>(dto));
            return Mapper.Map<ArticleDto>(article);
        }

        [Permission("article:write")]
        public void PublishArticle(Guid id)
        {
            _articleDomainService.Publish(id);
        }

        [Permission("article:write")]
        [Transaction(IsolationLevel.Serializable)]
        public ArticleDto Update(ArticleUpdateDto dto)
        {
            Article article = _articleDomainService.Get(dto.Id);
            Mapper.Map(dto, article);
            article = _articleDomainService.Update(article);
            return Mapper.Map<ArticleDto>(article);
        }

        [Permission("article:write")]
        public void Delete(Guid id)
        {
            Article article = _articleDomainService.Delete(id);
            // audit log - article deleted
        }

        [Permission("article:read")]
        public ArticleWithIncludeDto Get(Guid id, string include)
        {
            Article articleWithInclude = _articleDomainService.Get(id, include);
            return Mapper.Map<ArticleWithIncludeDto>(articleWithInclude);
        }

        [Permission("article:read")]
        public PagedListDto<ArticleWithIncludeDto> GetList(ArticleQueryDto dto, string include, Sorting sorting, Paging paging)
        {
            ArticleQueryCondition condition = Mapper.Map<ArticleQueryCondition>(dto); // condition & dto same?
            int count = _articleDomainService.GetCount(condition);
            IEnumerable<Article> list = _articleDomainService.GetList(condition, include, sorting, paging);
            return new PagedListDto<ArticleWithIncludeDto>(count, list.Select(e => Mapper.Map<ArticleWithIncludeDto>(e)));
        }
    }
}
