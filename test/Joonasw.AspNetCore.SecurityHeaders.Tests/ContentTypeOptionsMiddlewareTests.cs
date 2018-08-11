using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.XContentTypeOptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class ContentTypeOptionsMiddlewareTests
    {
        [Fact]
        public async Task HeaderSetCorrectlyWithNoSniffing()
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers["X-Content-Type-Options"];
                return Task.CompletedTask;
            };
            var options = Options.Create(new XContentTypeOptionsOptions
            {
                AllowSniffing = false
            });
            var mockContext = new DefaultHttpContext();
            var sut = new XContentTypeOptionsMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.Equal("nosniff", headerValue);
        }
    }
}
