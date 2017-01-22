using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.Hpkp.Options;
using Microsoft.AspNetCore.Http;

namespace Joonasw.AspNetCore.SecurityHeaders.Hpkp
{
    public class HpkpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _headerName;
        private readonly string _headerValue;

        public HpkpMiddleware(RequestDelegate next, HpkpOptions options)
        {
            _next = next;
            _headerName = options.HeaderName;
            _headerValue = options.HeaderValue;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(_headerName, _headerValue);
            await _next(context);
        }
    }
}