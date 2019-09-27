﻿using AutoMapper;
using Comm100.Application.Services;
using Comm100.Runtime;
using KB.Application.Articles.Dto;
using KB.Domain.Articles.Entity;
using KB.Domain.Articles.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Articles
{
    public class ArticleTagsAppService : AppServiceBase, IArticleTagsAppService
    {
        private IArticleTagsDomainService _articleTagsDomainService;

        public ArticleTagsAppService(IArticleTagsDomainService articleTagsDomainService) : base()
        {
            this._articleTagsDomainService = articleTagsDomainService;
            var configuration = new MapperConfiguration(config => 
            {
                config.CreateMap<ArticleTags, ArticleTagsDto>();
                config.CreateMap<ArticleTagsDto, ArticleTags>();
                config.CreateMap<ArticleTag, string>().ConvertUsing(t => t.Tag);
                config.CreateMap<string, ArticleTag>().ConvertUsing(t => new ArticleTag() { Tag = t });
            });
            this.Mapper = configuration.CreateMapper();
        }

        [Permission("article:write")]
        public ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.AddTags(id, Mapper.Map<ArticleTags>(dto));
            return Mapper.Map<ArticleTagsDto>(tags);
        }

        [Permission("article:write")]
        public ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.DeleteTags(id, Mapper.Map<ArticleTags>(dto));
            return Mapper.Map<ArticleTagsDto>(tags);
        }

        [Permission("article:read")]
        public ArticleTagsDto GetTags(Guid id)
        {
            var tags = _articleTagsDomainService.GetTags(id);
            return Mapper.Map<ArticleTagsDto>(tags);
        }

        [Permission("article:write")]
        public ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.UpdateTags(id, Mapper.Map<ArticleTags>(dto));
            return Mapper.Map<ArticleTagsDto>(tags);
        }
    }
}
