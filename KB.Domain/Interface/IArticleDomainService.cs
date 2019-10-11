using Comm100.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Domain.Services;
using KB.Domain.Entities;

namespace KB.Domain.Articles.Service
{
    public interface IArticleDomainService : IDomainService
    {
        void Publish(Article articleId);
    }
}
