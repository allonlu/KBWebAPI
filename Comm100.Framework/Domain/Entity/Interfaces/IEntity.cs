//-----------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Domain.Entity
{
    using System;
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
    public interface IEntity : IEntity<int> { }

    public interface IGuidEntity : IEntity<Guid> { }
}
