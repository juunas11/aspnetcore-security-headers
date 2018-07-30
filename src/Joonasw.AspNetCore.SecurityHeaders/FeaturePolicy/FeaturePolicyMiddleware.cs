using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy
{
    public class FeaturePolicyMiddleware
    {
        private const string HeaderName = "Feature-Policy";
        private readonly RequestDelegate _next;
        private readonly string _headerValue;

        public FeaturePolicyMiddleware(RequestDelegate next, IOptions<FeaturePolicyOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _next = next;
            _headerValue = options.Value.ToString();
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if a Feature Policy header has already been added to the response
            // This can happen for example if a middleware re-executes the pipeline
            if (!ContainsFeaturePolicyHeader(context.Response))
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }

            await _next.Invoke(context);
        }

        private static bool ContainsFeaturePolicyHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
