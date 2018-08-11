using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.XFrameOptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class FrameOptionsMiddlewareTests
    {
        [Theory]
        [InlineData(XFrameOptionsOptions.XFrameOptionsValues.Deny, null, "DENY")]
        [InlineData(XFrameOptionsOptions.XFrameOptionsValues.SameOrigin, null, "SAMEORIGIN")]
        [InlineData(XFrameOptionsOptions.XFrameOptionsValues.AllowFrom, "https://site.com", "ALLOW-FROM https://site.com")]
        public async Task HeaderSetCorrectly(
            XFrameOptionsOptions.XFrameOptionsValues value,
            string allowedUrl,
            string expectedValue)
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers["X-Frame-Options"];
                return Task.CompletedTask;
            };
            var options = Options.Create(new XFrameOptionsOptions
            {
                HeaderValue = value,
                AllowFromUrl = allowedUrl
            });
            var mockContext = new DefaultHttpContext();
            var sut = new XFrameOptionsMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.Equal(expectedValue, headerValue);
        }
    }
}
