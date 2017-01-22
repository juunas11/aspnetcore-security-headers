namespace Joonasw.AspNetCore.SecurityHeaders.Samples.Models
{
    public class CspViolationReport
    {
        /* JSON format:
         * 
         * {"csp-report":
         *  {"document-uri":"http://localhost:15490/",
         *    "referrer":"",
         *    "violated-directive":"connect-src 'self' https:",
         *    "effective-directive":"connect-src",
         *    "original-policy":"default-src https:;script-src 'self' https: ajax.aspnetcdn.com 'nonce-ZlcKG0OPAdcghg6c1EJpFOPbCHQKv6IsZRKZbBNaakE=';style-src 'self' https: ajax.aspnetcdn.com 'nonce-ZlcKG0OPAdcghg6c1EJpFOPbCHQKv6IsZRKZbBNaakE=';child-src 'none';connect-src 'self' https:;font-src 'self' https:;media-src 'none';object-src 'none';frame-ancestors 'none';report-uri /csp-report",
         *    "blocked-uri":"http://localhost:1591/2be9ad3d3c2e4eb3aee5c0f7b76f8714/browserLinkSignalR/negotiate?requestUrl=http%3A%2F%2Flocalhost%3A15490%2F&browserName=&userAgent=Mozilla%2F5.0+(Windows+NT+10.0%3B+Win64%3B+x64)+AppleWebKit%2F537.36+(KHTML%2C+like+Gecko)+Chrome%2F55.0.2883.87+Safari%2F537.36&clientProtocol=1.3&_=1485109104042",
         *    "line-number":37,
         *    "column-number":85935,
         *    "source-file":"http://localhost:1591/2be9ad3d3c2e4eb3aee5c0f7b76f8714/browserLink",
         *    "status-code":200
         *  }
         * }
         */
    }
}
