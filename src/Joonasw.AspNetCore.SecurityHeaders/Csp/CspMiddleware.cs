using System;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Microsoft.AspNetCore.Http;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public class CspMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CspOptions _options;

        public CspMiddleware(RequestDelegate next, CspOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            var nonceService = (CspNonceService)context.RequestServices.GetService(typeof(CspNonceService));

            Tuple<string, string> header = _options.ToString(nonceService);

            context.Response.Headers.Add(header.Item1, header.Item2);
            await _next.Invoke(context);
        }
    }
}
