using System;
using Microsoft.AspNetCore.Authentication;

namespace Comm100.Framework.Authentication
{
    public class JwtBearerAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Audience { get; set; }
    }
}
