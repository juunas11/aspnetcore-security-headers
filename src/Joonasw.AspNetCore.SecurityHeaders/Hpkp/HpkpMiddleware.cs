using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Hpkp
{
    public class HpkpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _headerName;
        private readonly string _headerValue;

        public HpkpMiddleware(RequestDelegate next, IOptions<HpkpOptions> options)
        {
            _next = next;
            _headerName = options.Value.HeaderName;
            _headerValue = options.Value.HeaderValue;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!ContainsHpkpHeader(context.Response))
            {
                context.Response.Headers.Add(_headerName, _headerValue);
            }
            await _next(context);
        }

        private bool ContainsHpkpHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(HpkpOptions.BlockingHeaderName, StringComparison.OrdinalIgnoreCase)
                || h.Key.Equals(HpkpOptions.ReportOnlyHeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}