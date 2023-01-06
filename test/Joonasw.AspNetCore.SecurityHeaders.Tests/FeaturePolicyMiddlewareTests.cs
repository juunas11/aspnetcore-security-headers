using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class FeaturePolicyMiddlewareTests
    {
        [Fact]
        public async Task FeaturePolicyHeaderAddedCorrectly()
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers["Permissions-Policy"];
                return Task.CompletedTask;
            };
            var options = Options.Create(new FeaturePolicyOptions
            {
                Autoplay = new FeaturePolicyAutoplayOptions
                {
                    AllowSelf = true
                },
                Payment = new FeaturePolicyPaymentOptions
                {
                    AllowNone = true
                },
                Speaker = new FeaturePolicySpeakerOptions
                {
                    AllowSelf = true,
                    AllowedOrigins = new List<string>
                    {
                        "https://site1",
                        "https://site2"
                    }
                },
                Other = new Dictionary<string, FeaturePolicyOptionsBase>
                {
                    ["some-new-one"] = new FeaturePolicyOtherFeatureOptions("some-new-one")
                    {
                        AllowSelf = true
                    }
                }
            });
            var mockContext = new DefaultHttpContext();
            var sut = new FeaturePolicyMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.Equal("speaker 'self' https://site1 https://site2; payment 'none'; autoplay 'self'; some-new-one 'self'", headerValue);
        }
    }
}
