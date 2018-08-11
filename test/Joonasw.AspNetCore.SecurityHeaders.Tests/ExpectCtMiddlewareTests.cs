using System;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.ExpectCT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class ExpectCtMiddlewareTests
    {
        [Fact]
        public async Task SetsHeaderCorrectlyWithoutEnforce()
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers["Expect-CT"];
                return Task.CompletedTask;
            };
            var options = Options.Create(new ExpectCTOptions
            {
                Enforce = false,
                ReportUri = "https://reporting.com/report",
                MaxAge = TimeSpan.FromHours(1)
            });
            var mockContext = new DefaultHttpContext();
            mockContext.Request.Scheme = "https";
            var sut = new ExpectCTMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.Equal("max-age=3600, report-uri=\"https://reporting.com/report\"", headerValue);
        }

        [Fact]
        public async Task SetsHeaderCorrectlyWithEnforce()
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers["Expect-CT"];
                return Task.CompletedTask;
            };
            var options = Options.Create(new ExpectCTOptions
            {
                Enforce = true,
                ReportUri = "https://reporting.com/report",
                MaxAge = TimeSpan.FromHours(1)
            });
            var mockContext = new DefaultHttpContext();
            mockContext.Request.Scheme = "https";
            var sut = new ExpectCTMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.Equal("max-age=3600, enforce, report-uri=\"https://reporting.com/report\"", headerValue);
        }
    }
}
