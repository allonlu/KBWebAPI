//-----------------------------------------------------------------------
// <copyright file="EntityNotFoundException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Exception
{
    using System;

    public class EntityNotFoundException : BaseException
    {
        public Type EntityType { get; set; }
        public Guid Id { get; set; }

        public override string Message => string.Format(base.Message, EntityType.Name, Id);

        public EntityNotFoundException(Guid id, Type entityType) : this(id)
        {
            EntityType = entityType;

        }
        public EntityNotFoundException(Guid id) : base(100101,ErrorMessages.E100101)
        {
            Id = id;
        }
    }
}
