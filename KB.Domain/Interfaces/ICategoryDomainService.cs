using Comm100.Framework.Domain.Services;
using KB.Domain.Bo;
using KB.Domain.Entities;
using KB.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Interfaces
{
    public interface ICategoryDomainService : IDomainService
    {
        Category Create(Category category);

        Category Get(Guid id);

        Category Update(CategoryUpdateBo id);

        IEnumerable<Category> List();

        void DeleteAndAdoptChildren(Guid id, Guid targetId);

        void Delete(Guid id);

    }
}
