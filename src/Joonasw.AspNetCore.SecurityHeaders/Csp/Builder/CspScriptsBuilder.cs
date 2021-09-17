using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to JavaScript.
    /// </summary>
    public class CspScriptsBuilder
    {
        private readonly CspScriptSrcOptions _options = new CspScriptSrcOptions();

        /// <summary>
        /// Block all JavaScript.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow JavaScript from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspScriptsBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow JavaScript from the given
        /// <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspScriptsBuilder From(string uri)
        {
            if(uri == null) throw new ArgumentNullException(nameof(uri));
            if(uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow inline scripts.
        /// If you have an XSS vulnerability, this will allow them to execute.
        /// Cannot be enabled together with AddNonce.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspScriptsBuilder AllowUnsafeInline()
        {
            _options.AllowUnsafeInline = true;
            return this;
        }

        /// <summary>
        /// Allow usage of eval(). Do not enable unless you really
        /// need it.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspScriptsBuilder AllowUnsafeEval()
        {
            _options.AllowUnsafeEval = true;
            return this;
        }

        /// <summary>
        /// Generates a random nonce for each request and
        /// adds it to the CSP header. Allows inline scripts that
        /// have the nonce attribute set to the random value on
        /// the script element.
        /// Note that you must call AddCsp() on the service collection
        /// in ConfigureServices() to add the necessary dependencies.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspScriptsBuilder AddNonce()
        {
            _options.AddNonce = true;
            return this;
        }
        public CspScriptsBuilder AddSha256()
        {
            _options.AddSha256 = true;
            return this;
        }

        /// <summary>
        /// Allow JavaScript from anywhere, except
        /// data:, blob:, and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspScriptsBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow JavaScript only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspScriptsBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        /// <summary>
        /// Allow scripts that have been loaded with
        /// a trusted hash/nonce to load additional
        /// scripts.
        /// This enabled a &quot;strict&quot; mode
        /// for scripts, requiring a hash or nonce
        /// on all of them.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspScriptsBuilder WithStrictDynamic()
        {
            _options.StrictDynamic = true;
            return this;
        }

        public CspScriptSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}
