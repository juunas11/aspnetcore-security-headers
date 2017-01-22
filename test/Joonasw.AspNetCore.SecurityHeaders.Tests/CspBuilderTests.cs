using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
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
    }
}
