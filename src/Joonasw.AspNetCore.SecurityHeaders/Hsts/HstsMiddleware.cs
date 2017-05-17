using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Joonasw.AspNetCore.SecurityHeaders.Hsts
{
    public class HstsMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HeaderName = "Strict-Transport-Security";
        private readonly string _headerValue;

        public HstsMiddleware(RequestDelegate next, HstsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            if (options.DurationSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(options.DurationSeconds), "HSTS duration must be positive");
            }

            _next = next;
            
            string headerValue = "max-age=" + options.DurationSeconds;
            if (options.IncludeSubDomains)
            {
                headerValue += "; includeSubDomains";
            }
            if (options.Preload)
            {
                headerValue += "; preload";
            }
            _headerValue = headerValue;
        }

        public async Task Invoke(HttpContext context)
        {
            //HSTS can only be applied to secure requests according to spec
            // there really is no point adding it to insecure ones since MiTM can just strip the header
            if (context.Request.IsHttps)
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }
            await _next(context);
        }
    }
}