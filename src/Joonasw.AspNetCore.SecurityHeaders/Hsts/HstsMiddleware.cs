using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Joonasw.AspNetCore.SecurityHeaders.Hsts
{
    public class HstsMiddleware
    {
        private const string HeaderName = "Strict-Transport-Security";
        private readonly RequestDelegate _next;
        private readonly string _headerValue;

        public HstsMiddleware(RequestDelegate next, HstsOptions options)
        {
            _next = next;
            _headerValue = options.BuildHeaderValue();
        }

        public async Task Invoke(HttpContext context)
        {
            //HSTS can only be applied to secure requests according to spec
            // there really is no point adding it to insecure ones since MiTM can just strip the header
            if (context.Request.IsHttps)
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }
            await _next(context);
        }
    }
}