using Microsoft.AspNetCore.Http;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public class CspSendingHeaderContext
    {
        /// <summary>
        /// The http context.
        /// </summary>
        public readonly HttpContext HttpContext;

        /// <summary>
        /// <c>true</c> iff the CSP header should not be sent, <c>false</c> otherwise.
        /// </summary>
        public bool ShouldNotSend { get; set; }

        public CspSendingHeaderContext(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }
    }
}
