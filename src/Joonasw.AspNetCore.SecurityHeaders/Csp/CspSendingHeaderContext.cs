using Microsoft.AspNetCore.Http;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public class CspSendingHeaderContext
    {
        public HttpContext HttpContext { get; }

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
