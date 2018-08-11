using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.XXssProtection
{
    public class XXssProtectionMiddleware
    {
        private const string HeaderName = "X-XSS-Protection";
        private readonly RequestDelegate _next;
        private readonly string _headerValue;

        public XXssProtectionMiddleware(RequestDelegate next, IOptions<XXssProtectionOptions> options)
        {
            _next = next;
            _headerValue = options.Value.BuildHeaderValue();
        }

        public async Task Invoke(HttpContext context)
        {
            if (!ContainsXXssProtectionHeader(context.Response))
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }
            await _next(context);
        }

        private static bool ContainsXXssProtectionHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
