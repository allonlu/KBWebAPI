namespace Comm100.Framework.Authentication.Session
{
    using System;

    public class NullSession : ISession
    {
        public static ISession Instance => new NullSession();

        public Role Role => throw new NotImplementedException();

        public string Application => throw new NotImplementedException();

        public int? SiteId => throw new NotImplementedException();

        public Guid? UserId => throw new NotImplementedException();

        public string IP => throw new NotImplementedException();
    }
}
