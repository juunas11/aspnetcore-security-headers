using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Joonasw.AspNetCore.SecurityHeaders.Hpkp;
using Joonasw.AspNetCore.SecurityHeaders.Hpkp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Hpkp.Options;
using Joonasw.AspNetCore.SecurityHeaders.Hsts;
using Microsoft.AspNetCore.Builder;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseCsp(this IApplicationBuilder app, Action<CspBuilder> builderAction)
        {
            var builder = new CspBuilder();
            builderAction(builder);

            CspOptions options = builder.BuildCspOptions();

            return app.UseMiddleware<CspMiddleware>(options);
        }

        public static IApplicationBuilder UseHsts(
            this IApplicationBuilder app,
            HstsOptions options)
        {
            return app.UseMiddleware<HstsMiddleware>(options);
        }

        public static IApplicationBuilder UseHpkp(
            this IApplicationBuilder app,
            Action<HpkpBuilder> builderAction)
        {
            var builder = new HpkpBuilder();
            builderAction(builder);
            HpkpOptions options = builder.BuildHpkpOptions();
            return app.UseMiddleware<HpkpMiddleware>(options);
        }
    }
}
