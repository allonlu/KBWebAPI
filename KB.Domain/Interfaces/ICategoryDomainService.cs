using KB.Domain.Bo;
using KB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Domain.Interfaces
{
    public interface ICategoryDomainService
    {
        Category Create(Category category);

        Category Get(Guid id);

        Category Update(CategoryUpdateBo id);

        IReadOnlyList<Category> List();

        void DeleteAndAdoptChildren(Guid id, Guid targetId);

        void Delete(Guid id);

    }
}
