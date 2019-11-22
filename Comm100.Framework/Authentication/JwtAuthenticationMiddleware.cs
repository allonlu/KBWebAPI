namespace Comm100.Framework.Authentication
{
    using Microsoft.AspNetCore.Builder;

    public static class JwtAuthenticationMiddleware
    {
        

        public static void UseJwtAuthentication(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // auth the jwt token
                // create the identity for current
                await next.Invoke();
            });
        }
    }
}
