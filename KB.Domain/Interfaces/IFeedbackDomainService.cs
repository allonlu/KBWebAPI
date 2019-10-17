using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Interfaces
{
    public interface IFeedbackDomainService
    {
        void DeleteByArticle(Guid articleId);
    }
}
