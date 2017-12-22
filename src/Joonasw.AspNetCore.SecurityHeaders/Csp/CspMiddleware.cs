using System;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public class CspMiddleware
    {
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
            if (_options.IsNonceNeeded)
            {
                _headerName = null;
                _headerValue = null;
            }
            else
            {
                //If nonces are not needed, we can cache them immediately
                var (headerName, headerValue) = _options.ToString(null);
                _headerName = headerName;
                _headerValue = headerValue;
            }
        }

        public async Task Invoke(HttpContext context)
        {
            var sendingHeaderContext = new CspSendingHeaderContext(context);
            await _options.SendingHeader(sendingHeaderContext);

            if (!sendingHeaderContext.ShouldNotSend)
            {
                string headerName;
                string headerValue;
                if (_options.IsNonceNeeded)
                {
                    var nonceService = (ICspNonceService)context.RequestServices.GetService(typeof(ICspNonceService));
                    (headerName, headerValue) = _options.ToString(nonceService);
                }
                else
                {
                    headerName = _headerName;
                    headerValue = _headerValue;
                }
                context.Response.Headers.Add(headerName, headerValue);
            }

            await _next.Invoke(context);
        }
    }
}
