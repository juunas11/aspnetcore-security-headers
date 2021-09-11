using System;
using System.Collections.Generic;
using Joonasw.AspNetCore.SecurityHeaders.ReportingEndpoints.Builder;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class ReportingEndpointsBuilderTests
    {
        [Fact]
        public void ReportingEndpointsBuilder_Should_SetEndpoints()
        {
            var builder = new ReportingEndpointsBuilder();
            builder.AddEndpoint("csp-endpoint", "https://example.com/csp-reports")
                   .AddEndpoint("hpkp-endpoint", "https://example.com/hpkp-reports");

            var options = builder.BuildOptions();

            Assert.Equal("csp-endpoint=\"https://example.com/csp-reports\",hpkp-endpoint=\"https://example.com/hpkp-reports\"", options.ToHeaderValue());
        }

        [Fact]
        public void ReportingEndpointsBuilder_ShouldThrowException_WhenGroupNameIsMissingValue()
        {
            var builder = new ReportingEndpointsBuilder();

            Assert.Throws<ArgumentNullException>("groupName", () => builder.AddEndpoint(null, null));
        }

        [Fact]
        public void ReportingEndpointsBuilder_ShouldThrowException_WhenGroupNameIsDuplicated()
        {
            var builder = new ReportingEndpointsBuilder();
            builder.AddEndpoint("csp-endpoint", "https://example.com/csp-reports");

            Assert.Throws<ArgumentException>("groupName", () => builder.AddEndpoint("csp-endpoint", null));
        }

        [Fact]
        public void ReportingEndpointsBuilder_ShouldThrowException_WhenUrlIsMissingValue()
        {
            var builder = new ReportingEndpointsBuilder();

            Assert.Throws<ArgumentNullException>("url", () => builder.AddEndpoint("csp-endpoint", null));
        }

        [Fact]
        public void ReportingEndpointsBuilder_ShouldThrowException_WhenUrlIsNotSecure()
        {
            var builder = new ReportingEndpointsBuilder();

            Assert.Throws<ArgumentException>("url", () => builder.AddEndpoint("csp-endpoint", "http://example.com/csp-reports"));
        }

        [Fact]
        public void ReportingEndpointsOptions_ShouldThrowException_WhenNoEndpointSpecified()
        {
            var options = new ReportingEndpointsOptions
            {
                Endpoints = new Dictionary<string, string>()
            };

            var builder = new ReportingEndpointsBuilder();

            Assert.Throws<InvalidOperationException>(() => options.Validate());
        }

        [Fact]
        public void ReportingEndpointsOptions_ShouldThrowException_WhenAnUrlIsNotSecure()
        {
            var options = new ReportingEndpointsOptions
            {
                Endpoints = new Dictionary<string, string>
                {
                    { "csp-endpoint", "https://example.com/csp-reports" },
                    { "hpkp-endpoint", "http://example.com/hpkp-reports" }
                }
            };

            var builder = new ReportingEndpointsBuilder();

            Assert.Throws<InvalidOperationException>(() => options.Validate());
        }
    }
}
