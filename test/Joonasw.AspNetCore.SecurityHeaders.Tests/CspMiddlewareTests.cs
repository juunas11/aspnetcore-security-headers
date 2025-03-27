using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class CspMiddlewareTests
    {
        [Fact]
        public async Task CspHeaderIsIncluded_WhenInvokedWithoutShouldNotSendDelegate()
        {
            bool cspHeaderExists = false;

            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                cspHeaderExists = ctx.Response.Headers.ContainsKey("Content-Security-Policy");
                return Task.CompletedTask;
            };

            var options = Options.Create(new CspOptions()
            {
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowAny = true
                }
            });
            var mockContext = new DefaultHttpContext();

            var sut = new CspMiddleware(mockNext, options);


            await sut.Invoke(mockContext);

            Assert.True(cspHeaderExists);
        }

        [Fact]
        public async Task CspHeaderIsIncluded_WhenInvokedWithShouldNotSendDelegate_ThatSetsShouldNotSendToTrue()
        {
            bool cspHeaderExists = false;

            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                cspHeaderExists = ctx.Response.Headers.ContainsKey("Content-Security-Policy");
                return Task.CompletedTask;
            };

            var options = Options.Create(new CspOptions()
            {
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowAny = true
                },
                OnSendingHeader = ctx =>
                {
                    ctx.ShouldNotSend = false;
                    return Task.CompletedTask;
                }
            });
            var mockContext = new DefaultHttpContext();

            var sut = new CspMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.True(cspHeaderExists);
        }

        [Fact]
        public async Task CspHeaderIsNotIncluded_WhenInvokedWithShouldNotSendDelegate_ThatSetsShouldNotSendToTrue()
        {
            bool cspHeaderExists = true;

            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                cspHeaderExists = ctx.Response.Headers.ContainsKey("Content-Security-Policy");
                return Task.CompletedTask;
            };

            var options = Options.Create(new CspOptions()
            {
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowAny = true
                },
                OnSendingHeader = ctx =>
                {
                    ctx.ShouldNotSend = true;
                    return Task.CompletedTask;
                }
            });
            var mockContext = new DefaultHttpContext();

            var sut = new CspMiddleware(mockNext, options);


            await sut.Invoke(mockContext);

            Assert.False(cspHeaderExists);
        }

        [Fact]
        public async Task CspHeaderIsNotIncluded_WhenRequestHeadersAlreadyContainCspHeader()
        {
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                return Task.CompletedTask;
            };
            var options = Options.Create(new CspOptions()
            {
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowAny = true
                }
            });
            var sut = new CspMiddleware(mockNext, options);
            var mockContext = new DefaultHttpContext();
            mockContext.Response.Headers.Append("Content-Security-Policy", "default-src https: 'unsafe-eval' 'unsafe-inline'; object-src 'none'");

            await sut.Invoke(mockContext);
            //Invoke throws System.ArgumentException if it tries to add the header again
        }

        [Fact]
        public async Task CspHeaderIsNotIncluded_WhenRequestHeadersAlreadyContainCspReportOnlyHeader()
        {
            bool cspHeaderExists = true;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                cspHeaderExists = ctx.Response.Headers.ContainsKey("Content-Security-Policy");
                return Task.CompletedTask;
            };
            var options = Options.Create(new CspOptions()
            {
                Default = new Csp.Options.CspDefaultSrcOptions
                {
                    AllowAny = true
                }
            });
            var sut = new CspMiddleware(mockNext, options);
            var mockContext = new DefaultHttpContext();
            mockContext.Response.Headers.Append("Content-Security-Policy-Report-Only", "default-src https: 'unsafe-eval' 'unsafe-inline'; object-src 'none'");

            await sut.Invoke(mockContext);

            //Header not added since a report-only version already is there
            Assert.False(cspHeaderExists);
        }
    }
}
