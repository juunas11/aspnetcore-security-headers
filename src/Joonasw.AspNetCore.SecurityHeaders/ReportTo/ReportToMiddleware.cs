using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.ReportTo
{
    public class ReportToMiddleware
    {
        private const string HeaderName = "Report-To";
        private readonly RequestDelegate _next;
        private readonly string _headerValue;

        public ReportToMiddleware(RequestDelegate next, IOptions<ReportToOptions> options)
        {
            _next = next;
            _headerValue = options.Value.BuildHeaderValue();
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if a CSP header has already been added to the response
            // This can happen for example if a middleware re-executes the pipeline
            if (!ContainsReportToHeader(context.Response))
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }
            await _next(context);
        }

        private bool ContainsReportToHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
