using AutoMapper;
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


        public override void OnMapperConfiguration(IProfileExpression config)
        {
            config.CreateMap<ArticleTags, ArticleTagsDto>();
            config.CreateMap<ArticleTagsDto, ArticleTags>();
        }

        public ArticleTagsAppService(IArticleTagsDomainService articleTagsDomainService) : base()
        {
            this._articleTagsDomainService = articleTagsDomainService;
        }

        [Permission("article.write")]
        public ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.AddTags(id, Mapper.Map<ArticleTags>(dto));
            return Mapper.Map<ArticleTagsDto>(tags);
        }

        [Permission("article.write")]
        public ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.DeleteTags(id, Mapper.Map<ArticleTags>(dto));
            return Mapper.Map<ArticleTagsDto>(tags);
        }

        [Permission("article.write")]
        public ArticleTagsDto GetTags(Guid id)
        {
            var tags = _articleTagsDomainService.GetTags(id);
            return Mapper.Map<ArticleTagsDto>(tags);
        }

        [Permission("article.write")]
        public ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.UpdateTags(id, Mapper.Map<ArticleTags>(dto));
            return Mapper.Map<ArticleTagsDto>(tags);
        }
    }
}
