using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public class CspMiddleware
    {
        private const string CspHeaderName = "Content-Security-Policy";
        private const string CspReportOnlyHeaderName = "Content-Security-Policy-Report-Only";
        private readonly RequestDelegate _next;
        private readonly CspOptions _options;
        private readonly string _headerName;
        private readonly string _headerValue;

        public CspMiddleware(RequestDelegate next, IOptions<CspOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _next = next;
            _options = options.Value;
            // If a nonce is needed to be generated, we can't cache the header value
            if (_options.IsNonceNeeded || _options.IsSha256Needed)
            {
                _headerName = null;
                _headerValue = null;
            }
            else
            {
                //If nonces are not needed, we can cache them immediately
                var (headerName, headerValue) = _options.ToString(null,null);
                _headerName = headerName;
                _headerValue = headerValue;
            }
        }

        public async Task Invoke(HttpContext context)
        {
            if (_options.IsSha256Needed)
                context.Response.OnStarting(() => OrigInvoke(context));
            else
                await OrigInvoke(context);
            await _next.Invoke(context);

        }
        public async Task OrigInvoke(HttpContext context)
        {
            // Check if a CSP header has already been added to the response
            // This can happen for example if a middleware re-executes the pipeline
                if (!ContainsCspHeader(context.Response))
            {
                var sendingHeaderContext = new CspSendingHeaderContext(context);
                //Call the per-request check if CSP should be sent
                await _options.OnSendingHeader(sendingHeaderContext);

                if (!sendingHeaderContext.ShouldNotSend)
                {
                    string headerName;
                    string headerValue;
                    if (_options.IsSha256Needed)
                    {
                        var shaService = (ICspSha256Service)context.RequestServices.GetService(typeof(ICspSha256Service));
                        (headerName, headerValue) = _options.ToString(null, shaService);
                    }
                    else if (_options.IsNonceNeeded)
                    {
                        var nonceService = (ICspNonceService)context.RequestServices.GetService(typeof(ICspNonceService));
                        (headerName, headerValue) = _options.ToString(nonceService,null);
                    }
                    else
                    {
                        headerName = _headerName;
                        headerValue = _headerValue;
                    }
                    context.Response.Headers.Add(headerName, headerValue);
                }
            }

        }

        private bool ContainsCspHeader(HttpResponse response)
        {
            return response.Headers.Any(h => h.Key.Equals(CspHeaderName, StringComparison.OrdinalIgnoreCase)
                || h.Key.Equals(CspReportOnlyHeaderName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
