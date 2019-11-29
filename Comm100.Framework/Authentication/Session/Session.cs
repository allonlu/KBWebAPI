//-----------------------------------------------------------------------
// <copyright file="Session.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Authentication.Session
{
    using System;
    using System.Security.Principal;
    using Microsoft.AspNetCore.Http;

    public class Session : ISession
    {
        private readonly UserIdentity _userIdentity;

        private readonly string _ip;

        public Session(IHttpContextAccessor accessor)
        {
            this._userIdentity = accessor.HttpContext.User.Identity as UserIdentity;
            this._ip = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public string IP => _ip;

        public int? SiteId => _userIdentity.SiteId;

        public Role Role => _userIdentity.Role;

        public string Application => _userIdentity.Application;

        public Guid? UserId => _userIdentity.UserId;
    }
}
