//-----------------------------------------------------------------------
// <copyright file="Session.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Authentication.Session
{
    using System;
    using System.Security.Claims;
    using System.Security.Principal;
    using Microsoft.AspNetCore.Http;

    public class Session : ISession
    {
        private readonly ClaimsIdentity _identity;

        private readonly string _ip;

        public Session(IHttpContextAccessor accessor)
        {
            this._identity = accessor.HttpContext.User.Identity as ClaimsIdentity;
            this._ip = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public string IP => _ip;

        public int? SiteId => _identity.GetSiteId();

        public Role Role => _identity.GetRole();

        public string Application => _identity.GetApplication();

        public Guid? UserId => _identity.GetUserId();
    }
}
