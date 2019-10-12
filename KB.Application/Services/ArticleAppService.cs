using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Comm100.Framework;
using KB.Application.Articles.Dto;
using KB.Domain.Entities;
using KB.Domain.Articles.Service;
using Comm100.Runtime;
using Comm100.Application.Services;
using Comm100.Runtime.Transactions;
using System.Transactions;
using Comm100.Public.Dto;
using KB.Application.Categories.Dto;
using Comm100.Framework.Domain.Repository;
using KB.Domain.Specificaitons;

namespace KB.Application.Articles
{
    public class ArticleAppService : AppServiceBase, IArticleAppService
    {

        private readonly IRepository<Guid, Article> _repository;
        private readonly IArticleDomainService _articleDomainService;

        public ArticleAppService(IRepository<Guid, Article> repository, IArticleDomainService articleDomainService) : base()
        {
            this._repository = repository;
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

                config.CreateMap<ArticleTagsDto, Article>();
                config.CreateMap<Article, ArticleTagsDto>();

                config.CreateMap<ArticleTag, string>().ConvertUsing(t => t.Tag);
                config.CreateMap<string, ArticleTag>().ConvertUsing(t => new ArticleTag() { Tag = t });
            });

            this.Mapper = configuration.CreateMapper();
        }

        [Permission("article:write")]
        [Transaction(IsolationLevel.Serializable)]
        public ArticleDto Add(ArticleCreateDto dto)
        {
            Article article = _repository.Create(Mapper.Map<Article>(dto));
            return Mapper.Map<ArticleDto>(article);
        }

        [Permission("article:write")]
        public void PublishArticle(Guid id)
        {
            Article article = _repository.Get(id);
            _articleDomainService.Publish(article);
            _repository.Update(article);
        }

        [Permission("article:write")]
        [Transaction(IsolationLevel.Serializable)]
        public ArticleDto Update(ArticleUpdateDto dto)
        {
            Article article = _repository.Get(dto.Id);
            Mapper.Map(dto, article);
            _repository.Update(article);
            return Mapper.Map<ArticleDto>(article);
        }

        [Permission("article:write")]
        public void Delete(Guid id)
        {
            Article article = _repository.Get(id);
            _repository.Delete(article);

            // audit log - article deleted
        }

        [Permission("article:read")]
        public ArticleWithIncludeDto Get(Guid id, string include)
        {
            Article article = _repository.Get(id);

            return Mapper.Map<ArticleWithIncludeDto>(article);
        }

        [Permission("article:read")]
        public PagedListDto<ArticleWithIncludeDto> GetList(ArticleQueryDto dto, string include, Paging paging)
        {
            var spec = new ArticleFilterPaginatedSpecification(dto.CategoryId, dto.Tag, dto.Keywords, paging);
            int count = _repository.Count(spec);
            var list = _repository.List(spec);
            return new PagedListDto<ArticleWithIncludeDto>(count, list.Select(e => Mapper.Map<ArticleWithIncludeDto>(e)));
        }
    }
}
