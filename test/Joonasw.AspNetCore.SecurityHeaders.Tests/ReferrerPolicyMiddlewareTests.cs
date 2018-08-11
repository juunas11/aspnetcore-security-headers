using System;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.ReferrerPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class ReferrerPolicyMiddlewareTests
    {
        [Fact]
        public async Task SetsHeaderCorrectlyWithSameOrigin()
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers["Referrer-Policy"];
                return Task.CompletedTask;
            };
            var options = Options.Create(new ReferrerPolicyOptions
            {
                PolicyValue = ReferrerPolicyOptions.ReferrerPolicyValue.SameOrigin
            });
            var mockContext = new DefaultHttpContext();
            var sut = new ReferrerPolicyMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.Equal("same-origin", headerValue);
        }
    }
}
