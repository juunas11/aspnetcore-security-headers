using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.UnitTests
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
    }
}
