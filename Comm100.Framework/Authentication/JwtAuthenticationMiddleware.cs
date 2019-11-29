namespace Comm100.Framework.Authentication
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;

    public static class JwtAuthenticationMiddleware
    {
        

        public static void UseJwtAuthentication(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // TODO
                // auth the jwt token
                var user = new UserIdentity(Role.AGENT, "portal", 10000, new System.Guid());
                var principal = new ClaimsPrincipal(user);
                await context.SignInAsync(principal);
                await next.Invoke();
            });
        }
    }
}
