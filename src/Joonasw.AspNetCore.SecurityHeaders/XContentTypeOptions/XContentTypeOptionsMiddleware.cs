using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.XContentTypeOptions
{
    public class XContentTypeOptionsMiddleware
    {
        private const string HeaderName = "X-Content-Type-Options";
        private readonly RequestDelegate _next;
        private readonly string _headerValue;

        public XContentTypeOptionsMiddleware(RequestDelegate next, IOptions<XContentTypeOptionsOptions> options)
        {
            _next = next;
            _headerValue = options.Value.AllowSniffing ? string.Empty : "nosniff";
        }

        public async Task Invoke(HttpContext context)
        {
            // Let's just not bother with adding the header if they want to allow sniffing
            if (!string.IsNullOrWhiteSpace(_headerValue) && !ContainsXContentTypeOptionsHeader(context.Response))
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }
            await _next(context);
        }

        private static bool ContainsXContentTypeOptionsHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
