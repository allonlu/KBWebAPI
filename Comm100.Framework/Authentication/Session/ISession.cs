//-----------------------------------------------------------------------
// <copyright file="ISession.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Authentication.Session
{
    using System;

    public interface ISession
    {
        Role Role { get; }

        string Application { get; }

        int? SiteId { get; }

        Guid? UserId { get; }

        string IP { get; }
    }
}
