using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.ExpectCT
{
    public class ExpectCTMiddleware
    {
        private const string HeaderName = "Expect-CT";
        private readonly RequestDelegate _next;
        private readonly string _headerValue;

        public ExpectCTMiddleware(RequestDelegate next, IOptions<ExpectCTOptions> options)
        {
            _next = next;
            _headerValue = options.Value.HeaderValue;
        }

        public async Task Invoke(HttpContext context)
        {
            //Expect-CT can only be applied to secure requests according to spec
            if (context.Request.IsHttps && !ContainsExpectCTHeader(context.Response))
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }
            await _next(context);
        }

        private static bool ContainsExpectCTHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
