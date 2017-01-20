using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Joonasw.AspNetCore.SecurityHeaders.Hsts
{
    public class HstsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HstsOptions _options;

        public HstsMiddleware(RequestDelegate next, HstsOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            string headerName = "Strict-Transport-Security";
            string headerValue = $"max-age={_options.Seconds}";
            await _next(context);
        }
    }
}