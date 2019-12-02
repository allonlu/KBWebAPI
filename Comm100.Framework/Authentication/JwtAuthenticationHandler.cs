using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Comm100.Framework.Authentication
{
    public class JwtAuthenticationHandler : AuthenticationHandler<JwtBearerAuthenticationOptions>
    {
        public JwtAuthenticationHandler(
            IOptionsMonitor<JwtBearerAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new[] {
                new Claim(ClaimTypes.Role, Role.AGENT.ToString()),
                new Claim(ClaimTypes.NameIdentifier, new Guid().ToString()),
                new Claim(ClaimTypes.Name, "Allon"),
                new Claim(Comm100ClaimTypes.SITE_ID, "10000"),
                new Claim(Comm100ClaimTypes.APPLICATION, "kb-client"),
            };
            var identity = new ClaimsIdentity(claims, "Bearer");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Bearer");
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
