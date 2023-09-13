using System;
using System.Linq;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class CspStylesBuilderTests
    {
        [Fact]
        public void FromNowhere_SetsAllowNoneToTrue()
        {
            var builder = new CspStylesBuilder();

            builder.FromNowhere();
            CspStyleSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowNone);
        }

        [Fact]
        public void FromSelf_SetsAllowSelfToTrue()
        {
            var builder = new CspStylesBuilder();

            builder.FromSelf();
            CspStyleSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowSelf);
        }

        [Fact]
        public void From_AddsUrlToAllowedSources()
        {
            var builder = new CspStylesBuilder();

            builder.From("www.google.com");
            CspStyleSrcOptions options = builder.BuildOptions();

            Assert.Equal("www.google.com", options.AllowedSources.Single());
        }
        
        [Fact]
        public void From_ThrowsArgumentNullException_WithNullUrl()
        {
            var builder = new CspStylesBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.From(null));
        }

        [Fact]
        public void From_ThrowsArgumentException_WithEmptyUrl()
        {
            var builder = new CspStylesBuilder();

            Assert.Throws<ArgumentException>(() => builder.From(string.Empty));
        }
        
        [Fact]
        public void WithHash_AddsHashToAllowedHashes()
        {
            var builder = new CspStylesBuilder();

            builder.WithHash("sha256-RFWPLDbv2BY+rCkDzsE+0fr8ylGr2R2faWMhq4lfEQc=");
            CspStyleSrcOptions options = builder.BuildOptions();

            Assert.Equal("sha256-RFWPLDbv2BY+rCkDzsE+0fr8ylGr2R2faWMhq4lfEQc=", options.AllowedHashes.Single());
        }
        
        [Fact]
        public void WithHash_ThrowsArgumentNullException_WithNullUrl()
        {
            var builder = new CspStylesBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.WithHash(null));
        }

        [Fact]
        public void WithHash_ThrowsArgumentException_WithEmptyUrl()
        {
            var builder = new CspStylesBuilder();

            Assert.Throws<ArgumentException>(() => builder.WithHash(string.Empty));
        }

        [Fact]
        public void AllowUnsafeInline_SetsUnsafeInlineToTrue()
        {
            var builder = new CspStylesBuilder();

            builder.AllowUnsafeInline();
            CspStyleSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowUnsafeInline);
        }

        [Fact]
        public void AddNonce_SetsAddNonceToTrue()
        {
            var builder = new CspStylesBuilder();

            builder.AddNonce();
            CspStyleSrcOptions options = builder.BuildOptions();

            Assert.True(options.AddNonce);
        }

        [Fact]
        public void FromAnywhere_SetsAllowAnyToTrue()
        {
            var builder = new CspStylesBuilder();

            builder.FromAnywhere();
            CspStyleSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowAny);
        }

        [Fact]
        public void OnlyOverHttps_SetsAllowOnlyHttpsToTrue()
        {
            var builder = new CspStylesBuilder();

            builder.OnlyOverHttps();
            CspStyleSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowOnlyHttps);
        }
    }
}
