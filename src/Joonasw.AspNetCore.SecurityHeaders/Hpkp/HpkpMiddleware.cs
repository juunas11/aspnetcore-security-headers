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
            //Public-Key-Pins: (or Public-Key-Pins-Report-Only:)
            //pin-sha256="cUPcTAZWKaASuYWhhneDttWpY3oBAkE3h2+soZS7sWs=";
            //pin-sha256="M8HztCzM3elUxkcjR2S5P4hhyBNf6lHkmjAHKhpGPWE=";
            //max-age=5184000; includeSubDomains;
            //report-uri="https://www.example.org/hpkp-report"
        }
    }
}