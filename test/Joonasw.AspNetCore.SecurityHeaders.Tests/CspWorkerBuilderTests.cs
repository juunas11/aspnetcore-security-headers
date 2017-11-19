using System;
using System.Linq;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class CspWorkerBuilderTests
    {
        [Fact]
        public void FromNowhere_SetsAllowNoneToTrue()
        {
            var builder = new CspWorkerBuilder();

            builder.FromNowhere();
            CspWorkerSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowNone);
        }

        [Fact]
        public void FromSelf_SetsAllowSelfToTrue()
        {
            var builder = new CspWorkerBuilder();

            builder.FromSelf();
            CspWorkerSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowSelf);
        }

        [Fact]
        public void FromSelf_ReturnsCorrectString()
        {
            var builder = new CspWorkerBuilder();

            builder.FromSelf();
            CspWorkerSrcOptions options = builder.BuildOptions();

            Assert.Equal("worker-src 'self'", options.ToString(null));
        }

        [Fact]
        public void From_AddsUrlToAllowedSources()
        {
            var builder = new CspWorkerBuilder();

            builder.From("www.google.com");
            CspWorkerSrcOptions options = builder.BuildOptions();

            Assert.Equal("www.google.com", options.AllowedSources.Single());
        }

        [Fact]
        public void From_ThrowsArgumentNullException_WithNullUrl()
        {
            var builder = new CspWorkerBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.From(null));
        }

        [Fact]
        public void From_ThrowsArgumentException_WithEmptyUrl()
        {
            var builder = new CspWorkerBuilder();

            Assert.Throws<ArgumentException>(() => builder.From(string.Empty));
        }

        [Fact]
        public void FromAnywhere_SetsAllowAnyToTrue()
        {
            var builder = new CspWorkerBuilder();

            builder.FromAnywhere();
            CspWorkerSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowAny);
        }

        [Fact]
        public void OnlyOverHttps_SetsAllowOnlyHttpsToTrue()
        {
            var builder = new CspWorkerBuilder();

            builder.OnlyOverHttps();
            CspWorkerSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowOnlyHttps);
        }
    }
}