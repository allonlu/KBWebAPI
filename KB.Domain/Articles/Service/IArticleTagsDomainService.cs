﻿using KB.Domain.Articles.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Articles.Service
{
    public interface IArticleTagsDomainService
    {
        ArticleTags AddTags(Guid articleId, ArticleTags tags);

        ArticleTags GetTags(Guid articleId);

        ArticleTags UpdateTags(Guid articleId, ArticleTags tags);

        ArticleTags DeleteTags(Guid articleId, ArticleTags tags);

        void Delete(Guid articleId);
    }
}
