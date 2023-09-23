using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.ReportingEndpoints
{
    public class ReportingEndpointsMiddleware
    {
        private const string HeaderName = "Reporting-Endpoints";

        private readonly RequestDelegate _next;
        private readonly string _cachedHeaderValue;

        public ReportingEndpointsMiddleware(RequestDelegate next, IOptions<ReportingEndpointsOptions> options)
        {
            _next = next;
            _cachedHeaderValue = options.Value.ToHeaderValue();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!ContainsReportToHeader(context.Response))
                context.Response.Headers.Add(HeaderName, _cachedHeaderValue);

            await _next(context);
        }

        private bool ContainsReportToHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
