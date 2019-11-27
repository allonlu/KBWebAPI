//-----------------------------------------------------------------------
// <copyright file="Session.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Authentication.Session
{
    using System;

    public class Session : ISession
    {
        public string GetApplication()
        {
            throw new NotImplementedException();
        }

        public string GetIP()
        {
            throw new NotImplementedException();
        }

        public Role GetRole()
        {
            throw new NotImplementedException();
        }

        Guid? ISession.GetAgentId()
        {
            throw new NotImplementedException();
        }

        int? ISession.GetSiteId()
        {
            throw new NotImplementedException();
        }
    }
}
