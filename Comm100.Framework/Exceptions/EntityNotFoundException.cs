//-----------------------------------------------------------------------
// <copyright file="EntityNotFoundException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Exceptions
{
    using System;

    [HttpStatus(System.Net.HttpStatusCode.NotFound)]
    public class EntityNotFoundException : BaseException
    {
        public EntityNotFoundException(Guid id, Type entityType)
            :base(string.Format(ErrorMessages.ENTITY_NOT_FOUND, entityType.Name, id.ToString()))
        {
        }
    }
}
