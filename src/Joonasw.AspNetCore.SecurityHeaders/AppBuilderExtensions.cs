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
    /// <summary>
    /// Extensions for adding security header middleware to the
    /// ASP.NET Core request pipeline.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Adds a Content Security Policy header
        /// to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="builderAction">Configuration action for the header.</param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseCsp(this IApplicationBuilder app, Action<CspBuilder> builderAction)
        {
            var builder = new CspBuilder();
            builderAction(builder);

            CspOptions options = builder.BuildCspOptions();

            return app.UseMiddleware<CspMiddleware>(options);
        }

        /// <summary>
        /// Adds a HTTP Strict Transport Security header
        /// to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="options"></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseHsts(
            this IApplicationBuilder app,
            HstsOptions options)
        {
            return app.UseMiddleware<HstsMiddleware>(options);
        }

        /// <summary>
        /// Adds a HTTP Public Key Pins header
        /// to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="builderAction">Configuration action for the header.</param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
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
