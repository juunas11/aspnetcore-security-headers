using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.ReferrerPolicy
{
    public class ReferrerPolicyMiddleware
    {
        private const string HeaderName = "Referrer-Policy";
        private readonly RequestDelegate _next;
        private readonly string _headerValue;

        public ReferrerPolicyMiddleware(RequestDelegate next, IOptions<ReferrerPolicyOptions> options)
        {
            _next = next;
            _headerValue = options.Value.PolicyValue.DefaultValue();
        }

        public async Task Invoke(HttpContext context)
        {
            if (!ContainsReferrerPolicyHeader(context.Response))
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }
            await _next(context);
        }

        private static bool ContainsReferrerPolicyHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
