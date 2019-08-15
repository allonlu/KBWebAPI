using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Comm100.Framework;
using KB.Application.Articles.Dto;
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
                cfg.CreateMap<ArticleTagsDto, ArticleTags>();
                cfg.CreateMap<ArticleTags, ArticleTagsDto>();
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

        public PagedListDto<ArticleWithIncludeDto> GetList(ArticleQueryDto dto, string include, Sorting sorting, Paging paging)
        {
            var condition = _mapper.Map<ArticleQueryCondition>(dto);
            var count = _articleDomainService.GetCount(condition);
            var list = _articleDomainService.GetList(condition, include, sorting, paging);
            return new PagedListDto<ArticleWithIncludeDto>(count, list.Select(e => _mapper.Map<ArticleWithIncludeDto>(e)));
        }

        public ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.AddTags(id, _mapper.Map<ArticleTags>(dto));
            return _mapper.Map<ArticleTagsDto>(tags);
        }

        public ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.DeleteTags(id, _mapper.Map<ArticleTags>(dto));
            return _mapper.Map<ArticleTagsDto>(tags);
        }


        public ArticleTagsDto GetTags(Guid id)
        {
            var tags = _articleTagsDomainService.GetTags(id);
            return _mapper.Map<ArticleTagsDto>(tags);
        }

        public ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto)
        {
            var tags = _articleTagsDomainService.UpdateTags(id, _mapper.Map<ArticleTags>(dto));
            return _mapper.Map<ArticleTagsDto>(tags);
        }
    }
}
