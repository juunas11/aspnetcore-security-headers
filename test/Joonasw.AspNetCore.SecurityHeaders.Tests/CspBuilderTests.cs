using System;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class CspBuilderTests
    {
        [Fact]
        public void ReportViolationsTo_SetsTheReportUri()
        {
            var builder = new CspBuilder();

            builder.ReportViolationsTo("/somewhere");
            CspOptions options = builder.BuildCspOptions();

            Assert.Equal("/somewhere", options.ReportUri);
        }

        [Fact]
        public void ReportViolationsTo_ThrowsArgumentNullException_WithNullUrl()
        {
            var builder = new CspBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.ReportViolationsTo(null));
        }

        [Fact]
        public void ReportViolationsTo_ThrowsArgumentException_WithEmptyUrl()
        {
            var builder = new CspBuilder();

            Assert.Throws<ArgumentException>(() => builder.ReportViolationsTo(string.Empty));
        }

        [Fact]
        public void EnableSandbox_EnablesTheSandbox()
        {
            var builder = new CspBuilder();

            builder.EnableSandbox();
            CspOptions options = builder.BuildCspOptions();

            Assert.True(options.EnableSandbox);
        }

        [Fact]
        public void SetReportOnly_SetsReportOnlyToTrue()
        {
            var builder = new CspBuilder();

            builder.SetReportOnly();
            CspOptions options = builder.BuildCspOptions();

            Assert.True(options.ReportOnly);
        }

        [Fact]
        public void SetUpgradeInsecureRequests_SetsUpgradeInsecureRequestsToTrue()
        {
            var builder = new CspBuilder();

            builder.SetUpgradeInsecureRequests();
            CspOptions options = builder.BuildCspOptions();

            Assert.True(options.UpgradeInsecureRequests);
        }

        [Fact]
        public void SetBlockAllMixedContent_SetsBlockAllMixedContentToTrue()
        {
            var builder = new CspBuilder();

            builder.SetBlockAllMixedContent();
            CspOptions options = builder.BuildCspOptions();

            Assert.True(options.BlockAllMixedContent);
        }

        [Fact]
        public void WithFramesAndWorkers_ReturnsCorrectHeader()
        {
            var builder = new CspBuilder();

            builder.AllowFrames.From("https://www.google.com");
            builder.AllowWorkers.FromSelf().OnlyOverHttps();

            var headerValue = builder.BuildCspOptions().ToString(null).headerValue;

            Assert.Equal("frame-src https://www.google.com;worker-src 'self' https:", headerValue);
        }

        [Fact]
        public void WithPrefetch_ReturnsCorrectHeader()
        {
            var builder = new CspBuilder();

            builder.AllowPrefetch.From("https://www.google.com");

            var headerValue = builder.BuildCspOptions().ToString(null).headerValue;

            Assert.Equal("prefetch-src https://www.google.com", headerValue);
        }

        [Fact]
        public void WithManifest_ReturnsCorrectHeader()
        {
            var builder = new CspBuilder();

            builder.AllowManifest.From("https://www.google.com");

            var headerValue = builder.BuildCspOptions().ToString(null).headerValue;

            Assert.Equal("manifest-src https://www.google.com", headerValue);
        }

        [Fact]
        public void RequireSriFor_ReturnsCorrectHeader()
        {
            var builder = new CspBuilder();

            builder.RequireSri.ForScripts();

            var headerValue = builder.BuildCspOptions().ToString(null).headerValue;

            Assert.Equal("require-sri-for script", headerValue);
        }
        
        
        [Fact]
        public void RequireTrustedTypes_ReturnsCorrectHeader()
        {
            var builder = new CspBuilder();

            builder.RequireTrustedTypes.DisallowAll();

            var headerValue = builder.BuildCspOptions().ToString(null).headerValue;

            Assert.Equal("trusted-types 'none'", headerValue);
        }

        [Fact]
        public async Task OnSendingHeader_ShouldNotSendTest()
        {
            var builder = new CspBuilder
            {
                OnSendingHeader = context =>
                {
                    context.ShouldNotSend = true;
                    return Task.CompletedTask;
                }
            };

            var sendingHeaderContext = new CspSendingHeaderContext(null);
            await builder.BuildCspOptions().OnSendingHeader(sendingHeaderContext);

            Assert.True(sendingHeaderContext.ShouldNotSend);
        }
    }
}
