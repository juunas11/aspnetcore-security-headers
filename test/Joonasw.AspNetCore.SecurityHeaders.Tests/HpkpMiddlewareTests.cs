using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.Hpkp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class HpkpMiddlewareTests
    {
        [Fact]
        public async Task HpkpHeaderIsNotIncluded_WhenRequestHeadersAlreadyContainHpkpHeader()
        {
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                return Task.CompletedTask;
            };
            var options = Options.Create(new HpkpOptions()
            {
                MaxAgeSeconds = 60,
                Pins = new List<string>{"a"}
            });
            var sut = new HpkpMiddleware(mockNext, options);
            var mockContext = new DefaultHttpContext();
            mockContext.Response.Headers.Append("Public-Key-Pins", "abc; max-age=60");

            await sut.Invoke(mockContext);
            //Invoke throws System.ArgumentException if it tries to add the header again
        }

        [Fact]
        public async Task HpkpHeaderIsNotIncluded_WhenRequestHeadersAlreadyContainHpkpReportOnlyHeader()
        {
            bool hpkpHeaderExists = true;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                hpkpHeaderExists = ctx.Response.Headers.ContainsKey("Public-Key-Pins");
                return Task.CompletedTask;
            };
            var options = Options.Create(new HpkpOptions()
            {
                MaxAgeSeconds = 60,
                Pins = new List<string>{"a"}
            });
            var sut = new HpkpMiddleware(mockNext, options);
            var mockContext = new DefaultHttpContext();
            mockContext.Response.Headers.Append("Public-Key-Pins-Report-Only", "abc; max-age=60");

            await sut.Invoke(mockContext);

            Assert.False(hpkpHeaderExists);
        }
    }
}
