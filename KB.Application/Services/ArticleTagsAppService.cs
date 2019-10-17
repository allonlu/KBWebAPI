using AutoMapper;
using Comm100.Application.Services;
using Comm100.Runtime;
using KB.Application.Articles.Dto;
using KB.Domain.Entities;
using KB.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Articles
{
    public class ArticleTagsAppService : AppServiceBase, IArticleTagsAppService
    {
        private readonly IArticleDomainService _domainService;

        public ArticleTagsAppService(IArticleDomainService domainService) : base()
        {
            this._domainService = domainService;
            var configuration = new MapperConfiguration(config => 
            {
                config.CreateMap<Article, ArticleTagsDto>();
                config.CreateMap<ArticleTag, string>().ConvertUsing(t => t.Tag);
            });
            this.Mapper = configuration.CreateMapper();
        }

        [Permission("article:write")]
        public ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto)
        {
            var article = _domainService.AddTags(dto.Tags);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Permission("article:write")]
        public ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto)
        {
            Article article = _domainService.DeleteTags(dto.Tags);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Permission("article:read")]
        public ArticleTagsDto GetTags(Guid id)
        {
            Article article = _domainService.Get(id);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Permission("article:write")]
        public ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto)
        {
            Article article = _domainService.SetTags(dto.Tags);
            return Mapper.Map<ArticleTagsDto>(article);
        }
    }
}
