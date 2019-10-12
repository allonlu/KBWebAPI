using AutoMapper;
using Comm100.Application.Services;
using Comm100.Framework.Domain.Repository;
using Comm100.Runtime;
using KB.Application.Articles.Dto;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.Articles
{
    public class ArticleTagsAppService : AppServiceBase, IArticleTagsAppService
    {
        private readonly IRepository<Guid, Article> _repository;
        public ArticleTagsAppService(IRepository<Guid, Article> repository) : base()
        {
            this._repository = repository;
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
            Article article = _repository.Get(id);
            article.AddTags(dto.Tags);
            _repository.Update(article);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Permission("article:write")]
        public ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto)
        {
            Article article = _repository.Get(id);
            article.DeleteTags(dto.Tags);
            _repository.Update(article);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Permission("article:read")]
        public ArticleTagsDto GetTags(Guid id)
        {
            Article article = _repository.Get(id);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Permission("article:write")]
        public ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto)
        {
            Article article = _repository.Get(id);
            article.SetTags(dto.Tags);
            _repository.Update(article);
            return Mapper.Map<ArticleTagsDto>(article);
        }
    }
}
