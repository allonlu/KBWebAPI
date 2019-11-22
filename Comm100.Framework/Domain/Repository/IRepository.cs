//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Domain.Repository
{
    using System.Collections.Generic;
    using Comm100.Framework.Domain.Specifications;

    public interface IRepository<TId, TEntity>
    {
        TEntity Get(TId id);
        IReadOnlyList<TEntity> ListAll();
        IReadOnlyList<TEntity> List(ISpecification<TEntity> spec); 
        int Count(ISpecification<TEntity> spec);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        bool Exists(TId id);
    }
}
