using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.Hsts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class HstsMiddlewareTests
    {
        [Fact]
        public async Task HstsHeaderIsNotIncluded_WhenRequestHeadersAlreadyContainHstsHeader()
        {
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                return Task.CompletedTask;
            };
            var options = Options.Create(new HstsOptions()
            {
                Duration = TimeSpan.FromHours(1)
            });
            var sut = new HstsMiddleware(mockNext, options);
            var mockContext = new DefaultHttpContext();
            mockContext.Request.Scheme = "https";
            mockContext.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");

            await sut.Invoke(mockContext);
            //Invoke throws System.ArgumentException if it tries to add the header again
        }
    }
}
