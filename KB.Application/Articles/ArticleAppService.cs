using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Comm100.Framework;
using KB.Application.Articles.Dto;
using KB.Application.Articles.Service;
using KB.Domain.Articles.Entity;
using KB.Domain.Articles.Service;

namespace KB.Application.Articles
{
    public class ArticleAppService : IArticleAppService
    {

        private readonly IArticleDomainService _articleDomainService;

        private readonly IArticleTagsDomainService _articleTagsDomainService;

        private Mapper _mapper = null;

        public ArticleAppService(IArticleDomainService articleDomainService, IArticleTagsDomainService articleTagsDomainService)
        {
            this._articleDomainService = articleDomainService;
            this._articleTagsDomainService = articleTagsDomainService;
            

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDto>();
                cfg.CreateMap<ArticleWithInclude, ArticleWithIncludeDto>();
                cfg.CreateMap<ArticleCreateDto, Article>();
                cfg.CreateMap<ArticleUpdateDto, Article>();
                cfg.CreateMap<ArticleQueryDto, ArticleQueryCondition>();
                //cfg.CreateMap<ArticleTagsDto, ArticleTags>();
            });
        }

        public ArticleDto Add(ArticleCreateDto dto)
        {
            var article = this._articleDomainService.Add(_mapper.Map<Article>(dto));
            return _mapper.Map<ArticleDto>(article);
        }

        public void PublishArticle(Guid id)
        {
            _articleDomainService.Publish(id);
        }
        public ArticleDto Update(ArticleUpdateDto dto)
        {
            var article = _articleDomainService.Update(_mapper.Map<Article>(dto));
            return _mapper.Map<ArticleDto>(article);
        }


        public void Delete(Guid id)
        {
            var article = _articleDomainService.Delete(id);
            // audit log - article deleted
        }

        public ArticleWithIncludeDto Get(Guid id, string include)
        {
            var articleWithInclude = _articleDomainService.Get(id, include);
            return _mapper.Map<ArticleWithIncludeDto>(articleWithInclude);
        }

        public PagedListDto<ArticleWithIncludeDto> GetList(ArticleQueryDto dto)
        {
            var condition = _mapper.Map<ArticleQueryCondition>(dto);
            var tuple = _articleDomainService.GetList(condition);
            var count = tuple.Item1;
            var list = tuple.Item2;
            return new PagedListDto<ArticleWithIncludeDto>(count, list.Select(e => _mapper.Map<ArticleWithIncludeDto>(e)));
        }

        public ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto)
        {
            throw new NotImplementedException();
        }

        public ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto)
        {
            throw new NotImplementedException();
        }


        public ArticleTagsDto GetTags(Guid id)
        {
            throw new NotImplementedException();
        }

        public ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto)
        {
            throw new NotImplementedException();
        }

    }
}
