using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Tags
{
    public interface ITagDomainService
    {
        void DeleteByArticle(Guid articleId);
    }
}
