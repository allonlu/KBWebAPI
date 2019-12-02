using System;
using Microsoft.AspNetCore.Authentication;

namespace Comm100.Framework.Authentication
{
    public class CookieAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string CookieKey { get; set; }
    }
}
