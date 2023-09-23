using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;
using Joonasw.AspNetCore.SecurityHeaders.ReportingEndpoints;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class ReportingEndpointsMiddlewareTests
    {
        [Fact]
        public async Task HeaderShouldBeSetCorrectly()
        {
            var headerValue = (string)null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers["Reporting-Endpoints"];
                return Task.CompletedTask;
            };

            var options = Options.Create(new ReportingEndpointsOptions
            {
                Endpoints = new Dictionary<string, string>
                {
                    { "csp-endpoint", "https://example.com/csp-reports" },
                    { "hpkp-endpoint", "https://example.com/hpkp-reports" }
                }
            });
            var mockContext = new DefaultHttpContext();
            var sut = new ReportingEndpointsMiddleware(mockNext, options);

            await sut.InvokeAsync(mockContext);

            Assert.Equal("csp-endpoint=\"https://example.com/csp-reports\",hpkp-endpoint=\"https://example.com/hpkp-reports\"", headerValue);
        }
    }
}
