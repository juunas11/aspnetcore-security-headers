using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.ExpectCT;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Hpkp;
using Joonasw.AspNetCore.SecurityHeaders.Hpkp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Hsts;
using Joonasw.AspNetCore.SecurityHeaders.ReferrerPolicy;
using Joonasw.AspNetCore.SecurityHeaders.XContentTypeOptions;
using Joonasw.AspNetCore.SecurityHeaders.XFrameOptions;
using Joonasw.AspNetCore.SecurityHeaders.XXssProtection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

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
        public static IApplicationBuilder UseJoonaswCsp(this IApplicationBuilder app, Action<CspBuilder> builderAction)
        {
            var builder = new CspBuilder();
            builderAction(builder);

            CspOptions options = builder.BuildCspOptions();

            return app.UseMiddleware<CspMiddleware>(new OptionsWrapper<CspOptions>(options));
        }

        /// <summary>
        /// Adds a Content Security Policy header
        /// to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswCsp(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CspMiddleware>();
        }

        /// <summary>
        /// Adds a HTTP Strict Transport Security header
        /// to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="options"></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswHsts(
            this IApplicationBuilder app,
            HstsOptions options)
        {
            return app.UseMiddleware<HstsMiddleware>(new OptionsWrapper<HstsOptions>(options));
        }

        /// <summary>
        /// Adds a HTTP Strict Transport Security header
        /// to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswHsts(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HstsMiddleware>();
        }

        /// <summary>
        /// Adds a HTTP Public Key Pins header
        /// to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="builderAction">Configuration action for the header.</param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswHpkp(
            this IApplicationBuilder app,
            Action<HpkpBuilder> builderAction)
        {
            var builder = new HpkpBuilder();
            builderAction(builder);
            HpkpOptions options = builder.BuildHpkpOptions();
            return app.UseMiddleware<HpkpMiddleware>(new OptionsWrapper<HpkpOptions>(options));
        }

        /// <summary>
        /// Adds a HTTP Public Key Pins header
        /// to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswHpkp(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HpkpMiddleware>();
        }

        /// <summary>
        /// Sets the X-Frame-Options header to DENY by default
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJoonaswXFrameOptions(this IApplicationBuilder app)
        {
            return app.UseMiddleware<XFrameOptionsMiddleware>();
        }

        /// <summary>
        /// Sets the X-Frame-Options header
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJoonaswXFrameOptions(
            this IApplicationBuilder app,
            XFrameOptionsOptions options)
        {
            return app.UseMiddleware<XFrameOptionsMiddleware>(new OptionsWrapper<XFrameOptionsOptions>(options));
        }

        /// <summary>
        /// Sets the X-Xss-Protection header to enable AND block by default
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJoonaswXXssProtection(this IApplicationBuilder app)
        {
            return app.UseMiddleware<XXssProtectionMiddleware>();
        }

        /// <summary>
        /// Sets the  X-Xss-Protection header
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJoonaswXXssProtection(
            this IApplicationBuilder app,
            XXssProtectionOptions options)
        {
            return app.UseMiddleware<XXssProtectionMiddleware>(new OptionsWrapper<XXssProtectionOptions>(options));
        }

        /// <summary>
        /// Sets the X-Content-Type-Options header to nosniff by default
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJoonaswXContentTypeOptions(this IApplicationBuilder app)
        {
            return app.UseMiddleware<XContentTypeOptionsMiddleware>();
        }

        /// <summary>
        /// Sets the X-Content-Type-Options header
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJoonaswXContentTypeOptions(
            this IApplicationBuilder app,
            XContentTypeOptionsOptions options)
        {
            return app.UseMiddleware<XContentTypeOptionsMiddleware>(new OptionsWrapper<XContentTypeOptionsOptions>(options));
        }

        /// <summary>
        /// Sets the Referrer Policy header to no-referrer by default
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJoonaswReferrerPolicy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ReferrerPolicyMiddleware>();
        }

        /// <summary>
        /// Sets the Referrer Policy header
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJoonaswReferrerPolicy(
            this IApplicationBuilder app,
            ReferrerPolicyOptions options)
        {
            return app.UseMiddleware<ReferrerPolicyMiddleware>(new OptionsWrapper<ReferrerPolicyOptions>(options));
        }

        /// <summary>
        /// Adds a Feature Policy headerto the response.
        /// See https://github.com/WICG/feature-policy/blob/master/features.md for more information
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="builderAction">Configuration action for the header.</param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswFeaturePolicy(this IApplicationBuilder app, Action<FeaturePolicyBuilder> builderAction)
        {
            var builder = new FeaturePolicyBuilder();
            builderAction(builder);

            var options = builder.BuildFeaturePolicyOptions();

            return app.UseMiddleware<FeaturePolicyMiddleware>(new OptionsWrapper<FeaturePolicyOptions>(options));
        }

        /// <summary>
        /// Adds a Feature Policy header to the response.
        /// See https://github.com/WICG/feature-policy/blob/master/features.md for more information
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswFeaturePolicy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<FeaturePolicyMiddleware>();
        }

        /// <summary>
        /// Adds a Expect-CT Header to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="options"></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswExpectCT(
            this IApplicationBuilder app,
            ExpectCTOptions options)
        {
            return app.UseMiddleware<ExpectCTMiddleware>(new OptionsWrapper<ExpectCTOptions>(options));
        }

        /// <summary>
        /// Adds a Expect-CT header to the response.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseJoonaswExpectCT(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExpectCTMiddleware>();
        }
    }
}
