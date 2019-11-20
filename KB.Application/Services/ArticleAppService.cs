using System;
using System.Linq;
using AutoMapper;
using Comm100.Framework;
using KB.Domain.Entities;
using Comm100.Runtime;
using Comm100.Application.Services;
using Comm100.Runtime.Transactions;
using System.Transactions;
using Comm100.Public.Dto;
using KB.Domain.Specificaitons;
using Comm100.Extension;
using KB.Domain.Interfaces;
using KB.Application.Dto;
using KB.Domain.Bo;
using Comm100.Framework.AuditLog;
using Comm100.Framework.Authorization;
using KB.Domain;

namespace KB.Application.Articles
{
    public class ArticleAppService : AppServiceBase, IArticleAppService
    {
        private readonly IArticleDomainService _articleDomainService;
        private readonly ICategoryDomainService _categoryDomainService;
        private readonly ITagDomainService _tagDomainService;

        public ArticleAppService(IArticleDomainService articleDomainService, 
            ICategoryDomainService categoryDomainService) : base()
        {
            this._articleDomainService = articleDomainService;
            this._categoryDomainService = categoryDomainService;

            MapperConfiguration configuration = new MapperConfiguration(config => {

                // because tags should be included, and if not include we should not return a empty array []
                config.AllowNullCollections = true; 

                config.AddProfile(new AgentMapperProfile());
                config.AddProfile(new CategoryMapperProfile());
                
                config.CreateMap<Article, ArticleDto>();
                config.CreateMap<Article, ArticleWithIncludeDto>();
                config.CreateMap<ArticleTag, Guid>().ConvertUsing(t => t.TagId);
         
                config.CreateMap<ArticleCreateDto, Article>();
                config.CreateMap<ArticleUpdateDto, ArticleUpdateBo>();

                config.CreateMap<ArticleTagsDto, Article>();
                config.CreateMap<Article, ArticleTagsDto>();
            });

            this.Mapper = configuration.CreateMapper();
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.WRITE)]
        [Audit(EntityTypes.ARTICLE, AuditAction.CREATE)]
        [Transaction(IsolationLevel.Serializable)]
        public ArticleDto Add(ArticleCreateDto dto)
        {
            Article article = _articleDomainService.Create(Mapper.Map<Article>(dto));
            return Mapper.Map<ArticleDto>(article);
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.WRITE)]
        [Audit(EntityTypes.ARTICLE, AuditAction.UPDATE)]
        public void Publish(Guid id)
        {
            _articleDomainService.Publish(id);
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.WRITE)]
        [Transaction(IsolationLevel.Serializable)]
        [Audit(EntityTypes.ARTICLE, AuditAction.UPDATE)]
        public ArticleDto Update(ArticleUpdateDto dto)
        {
            Article article = _articleDomainService.Update(Mapper.Map<ArticleUpdateBo>(dto));
            return Mapper.Map<ArticleDto>(article);
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.WRITE)]
        [Audit(EntityTypes.ARTICLE, AuditAction.DESTROY)]
        public void Delete(Guid id)
        {
            Article article = _articleDomainService.Delete(id);
            // audit log - article deleted
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.READ)]
        public ArticleWithIncludeDto Get(Guid id, string include)
        {
            Article article = _articleDomainService.Get(id);

            ArticleWithIncludeDto dto = Mapper.Map<ArticleWithIncludeDto>(article);

            HandleInclude(dto, include);

            return dto;
        }

        private void HandleInclude(ArticleWithIncludeDto dto, string include)
        {
            if (!string.IsNullOrEmpty(include))
            {
                var entityIncludes = include.AnalyzeInclude();
                foreach (var entity in entityIncludes)
                {
                    switch (entity)
                    {
                        case "category":
                            dto.Category = Mapper.Map<CategoryRefDto>(_categoryDomainService.Get(dto.CategoryId));
                            break;
                        case "author":
                            dto.Author = null; // need call public module.
                            break;
                        case "tags":
                            dto.Tags = dto.TagIds.Select(id => Mapper.Map<TagRefDto>(_tagDomainService.Get(id)));
                            break;
                        default:
                            throw new Exception("Invalid include parameters.");
                    }
                }
            }
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.READ)]
        public PagedListDto<ArticleWithIncludeDto> GetList(ArticleQueryDto dto, string include, Paging paging)
        {
            var spec = new ArticleFilterSpecification(dto.CategoryId, dto.TagId, dto.Keywords);
            int count = _articleDomainService.Count(spec);
            spec.ApplyPaging(paging);
            var list = _articleDomainService.List(spec);

            var listIncludes = list.Select(e =>
            {
                ArticleWithIncludeDto toDto = Mapper.Map<ArticleWithIncludeDto>(e);
                HandleInclude(toDto, include);
                return toDto;
            });

            return new PagedListDto<ArticleWithIncludeDto>(count, list.Select(e => Mapper.Map<ArticleWithIncludeDto>(e)));
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.WRITE)]
        [Audit(EntityTypes.ARTICLE, AuditAction.UPDATE)]
        public ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto)
        {
            var article = _articleDomainService.AddTags(id, dto.TagIds);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.WRITE)]
        [Audit(EntityTypes.ARTICLE, AuditAction.UPDATE)]
        public ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto)
        {
            Article article = _articleDomainService.DeleteTags(id, dto.TagIds);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.READ)]
        public ArticleTagsDto GetTags(Guid id)
        {
            Article article = _articleDomainService.Get(id);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Authorization(EntityTypes.ARTICLE, AuthorizationType.WRITE)]
        [Audit(EntityTypes.ARTICLE, AuditAction.UPDATE)]
        public ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto)
        {
            Article article = _articleDomainService.SetTags(id, dto.TagIds);
            return Mapper.Map<ArticleTagsDto>(article);
        }
    }
}
