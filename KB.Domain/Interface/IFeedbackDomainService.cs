using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Service
{
    public interface IFeedbackDomainService
    {
        void DeleteByArticle(Guid articleId);
    }
}
