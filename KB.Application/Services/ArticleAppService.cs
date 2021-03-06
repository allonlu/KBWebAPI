﻿using System;
using System.Linq;
using AutoMapper;
using Comm100.Framework;
using KB.Domain.Entities;
using Comm100.Application.Services;
using System.Transactions;
using KB.Domain.Specificaitons;
using KB.Domain.Interfaces;
using KB.Application.Dto;
using KB.Domain.Bo;
using Comm100.Framework.Auditing;
using Comm100.Framework.Authorization;
using Comm100.Framework.Extension;
using Comm100.Framework.Infrastructure;
using Comm100.Public.Account.Dto;
using Comm100.Public.Account.Domain;
using Comm100.Public.Audit;

namespace KB.Application.Articles
{
    public class ArticleAppService : BaseAppService, IArticleAppService
    {
        private readonly IArticleDomainService _articleDomainService;
        private readonly ICategoryDomainService _categoryDomainService;
        private readonly ITagDomainService _tagDomainService;
        private readonly IAgentDomainService _agentDomainService;

        public ArticleAppService(IArticleDomainService articleDomainService, 
            ICategoryDomainService categoryDomainService,
            ITagDomainService tagDomainService,
            IAgentDomainService agentDomainService) : base()
        {
            this._articleDomainService = articleDomainService;
            this._categoryDomainService = categoryDomainService;
            this._tagDomainService = tagDomainService;
            this._agentDomainService = agentDomainService;
        }


        [Authorization(KBPermission.MANAGE_ARTICLES)]
        [Audit(KBEntity.ARTICLE, AuditAction.CREATE)]
        [Transaction(IsolationLevel.Serializable)]
        public ArticleDto Add(ArticleCreateDto dto)
        {
            Article article = _articleDomainService.Create(Mapper.Map<Article>(dto));
            return Mapper.Map<ArticleDto>(article);
        }

        [Authorization(KBPermission.MANAGE_ARTICLES)]
        [Audit(KBEntity.ARTICLE, AuditAction.UPDATE)]
        public void Publish(Guid id)
        {
            _articleDomainService.Publish(id);
        }

        [Authorization(KBPermission.MANAGE_ARTICLES)]
        [Transaction(IsolationLevel.Serializable)]
        [Audit(KBEntity.ARTICLE, AuditAction.UPDATE)]
        public ArticleDto Update(ArticleUpdateDto dto)
        {
            Article article = _articleDomainService.Update(Mapper.Map<ArticleUpdateBo>(dto));
            return Mapper.Map<ArticleDto>(article);
        }

        [Authorization(KBPermission.MANAGE_ARTICLES)]
        [Audit(KBEntity.ARTICLE, AuditAction.DESTROY)]
        public void Delete(Guid id)
        {
            Article article = _articleDomainService.Delete(id);
        }

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
                            dto.Author = Mapper.Map<AgentRefDto>(_agentDomainService.Get(dto.AuthorId));
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

        [Authorization(KBPermission.MANAGE_ARTICLES)]
        [Audit(KBEntity.ARTICLE, AuditAction.UPDATE)]
        public ArticleTagsDto AddTags(Guid id, ArticleTagsDto dto)
        {
            var article = _articleDomainService.AddTags(id, dto.TagIds);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Authorization(KBPermission.MANAGE_ARTICLES)]
        [Audit(KBEntity.ARTICLE, AuditAction.UPDATE)]
        public ArticleTagsDto DeleteTags(Guid id, ArticleTagsDto dto)
        {
            Article article = _articleDomainService.DeleteTags(id, dto.TagIds);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        public ArticleTagsDto GetTags(Guid id)
        {
            Article article = _articleDomainService.Get(id);
            return Mapper.Map<ArticleTagsDto>(article);
        }

        [Authorization(KBPermission.MANAGE_ARTICLES)]
        [Audit(KBEntity.ARTICLE, AuditAction.UPDATE)]
        public ArticleTagsDto SetTags(Guid id, ArticleTagsDto dto)
        {
            Article article = _articleDomainService.SetTags(id, dto.TagIds);
            return Mapper.Map<ArticleTagsDto>(article);
        }
    }
}
