using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.ReportTo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class ReportToMiddlewareTests
    {
        [Fact]
        public async Task ReportToHeaderSetCorrectly()
        {
            bool reportToHeaderExists = false;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                reportToHeaderExists = ctx.Response.Headers.ContainsKey("Report-To");
                return Task.CompletedTask;
            };
            var options = new ReportToOptions()
            {
                Groups = new[]
                {
                    new ReportToOptions.Group {
                        GroupName = "a",
                        MaxAgeSeconds = 60,
                        Endpoints = new []
                        {
                            new ReportToOptions.Group.Endpoint() { Url = "a" },
                        }
                    },
                },
            };
            
            var sut = new ReportToMiddleware(mockNext, Options.Create(options));
            var mockContext = new DefaultHttpContext();

            await sut.Invoke(mockContext);

            Assert.True(reportToHeaderExists);
        }
    }
}
