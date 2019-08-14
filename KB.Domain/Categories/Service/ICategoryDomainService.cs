using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Categories.Service
{
    public interface ICategoryDomainService
    {
        void Delete(Guid id);
    }
}
