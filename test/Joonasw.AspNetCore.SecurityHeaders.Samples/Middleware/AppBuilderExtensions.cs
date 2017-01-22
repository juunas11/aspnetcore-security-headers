using System;
using Microsoft.AspNetCore.Builder;

namespace Joonasw.AspNetCore.SecurityHeaders.Samples.Middleware
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseHttpsEnforcement(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            return app.UseMiddleware<EnforceHttpsMiddleware>();
        }
    }
}
