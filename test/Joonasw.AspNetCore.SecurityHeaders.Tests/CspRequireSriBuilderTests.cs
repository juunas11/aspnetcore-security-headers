using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class CspRequireSriBuilderTests
    {
        [Fact]
        public void NoOptions_DoesNotGenerateHeader()
        {
            var builder = new CspRequireSriBuilder();

            var options = builder.BuildOptions();

            Assert.True(string.IsNullOrWhiteSpace(options.ToString()));
        }

        [Fact]
        public void RequireScript_GeneratesHeader()
        {
            var builder = new CspRequireSriBuilder();
            builder.ForScripts();

            var options = builder.BuildOptions();

            Assert.Equal("require-sri-for script", options.ToString());
        }

        [Fact]
        public void RequireStyle_GeneratesHeader()
        {
            var builder = new CspRequireSriBuilder();
            builder.ForStyles();

            var options = builder.BuildOptions();

            Assert.Equal("require-sri-for style", options.ToString());
        }

        [Fact]
        public void RequireScriptAndStyle_GeneratesHeader()
        {
            var builder = new CspRequireSriBuilder();
            builder.ForScripts();
            builder.ForStyles();

            var options = builder.BuildOptions();

            Assert.Equal("require-sri-for script style", options.ToString());
        }
    }
}
