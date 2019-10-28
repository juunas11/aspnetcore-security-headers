using System;
using System.Linq;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
  using Csp;

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
        public void FromSelf_WithNonce_HasValue()
        {
          var nonceService = new CspNonceService(32);
          var nonce = nonceService.GetNonce();
      
          var builder = new CspBuilder();
          builder.AllowScripts.FromSelf().AddNonce();
            
          var headerValue = builder.BuildCspOptions().ToString(nonceService).headerValue;

          Assert.DoesNotContain("+", nonce);
          Assert.DoesNotContain("/", nonce);
          Assert.DoesNotContain("=", nonce);
      
          Assert.Equal($"script-src 'self' 'nonce-{nonce}'", headerValue);
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
        public void WithStrictDynamic_SetsStrictDynamicToTrue()
        {
            var builder = new CspScriptsBuilder();

            builder.WithStrictDynamic();
            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.True(options.StrictDynamic);
        }

        [Fact]
        public void WithoutWithStrictDynamic_LeavesStrictDynamicToFalse()
        {
            var builder = new CspScriptsBuilder();

            CspScriptSrcOptions options = builder.BuildOptions();

            Assert.False(options.StrictDynamic);
        }
    }
}