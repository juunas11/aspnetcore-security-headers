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
            _headerValue = options.Value.ReferrerPolicyValue.DefaultValue();
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(HeaderName, _headerValue);
            await _next(context);
        }
    }
}
