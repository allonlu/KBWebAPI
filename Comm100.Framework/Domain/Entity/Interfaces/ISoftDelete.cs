//-----------------------------------------------------------------------
// <copyright file="ISoftDelete.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Domain.Entity
{
    public interface ISoftDelete
    {
        /// <summary>
        ///  Used to mark an Entity as 'Deleted'
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
