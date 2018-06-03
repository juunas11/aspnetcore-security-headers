using System;
using System.Linq;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class CspScriptsBuilderTests
    {
        [Fact]
        public void FromNowhere_SetsAllowNoneToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.FromNowhere();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowNone);
        }

        [Fact]
        public void FromSelf_SetsAllowSelfToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.FromSelf();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowSelf);
        }

        [Fact]
        public void From_AddsUrlToAllowedSources()
        {
            var builder = new CspScriptsBuilder();

            builder.From("www.google.com");
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.Equal("www.google.com", options.AllowedSources.Single());
        }

        [Fact]
        public void From_ThrowsArgumentNullException_WithNullUrl()
        {
            var builder = new CspScriptsBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.From(null));
        }

        [Fact]
        public void From_ThrowsArgumentException_WithEmptyUrl()
        {
            var builder = new CspScriptsBuilder();

            Assert.Throws<ArgumentException>(() => builder.From(string.Empty));
        }

        [Fact]
        public void AllowUnsafeEval_SetsUnsafeEvalToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.AllowUnsafeEval();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowUnsafeEval);
        }

        [Fact]
        public void AllowUnsafeInline_SetsUnsafeInlineToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.AllowUnsafeInline();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowUnsafeInline);
        }

        [Fact]
        public void AddNonce_SetsAddNonceToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.AddNonce();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.AddNonce);
        }

        [Fact]
        public void FromAnywhere_SetsAllowAnyToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.FromAnywhere();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowAny);
        }

        [Fact]
        public void OnlyOverHttps_SetsAllowOnlyHttpsToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.OnlyOverHttps();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.AllowOnlyHttps);
        }

        [Fact]
        public void StrictDynamic_SetsStrictDynamicToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.StrictDynamic();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.StrictDynamic);
        }
    }
}