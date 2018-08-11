using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.XXssProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class XssProtectionMiddlewareTests
    {
        [Theory]
        [InlineData(false, false, "0")]
        [InlineData(false, true, "1")]
        [InlineData(true, true, "1; mode=block")]
        public async Task HeaderSetCorrectly(bool enableBlock, bool enableProtection, string expectedValue)
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers["X-XSS-Protection"];
                return Task.CompletedTask;
            };
            var options = Options.Create(new XXssProtectionOptions
            {
                EnableAttackBlock = enableBlock,
                EnableProtection = enableProtection
            });
            var mockContext = new DefaultHttpContext();
            var sut = new XXssProtectionMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.Equal(expectedValue, headerValue);
        }
    }
}
