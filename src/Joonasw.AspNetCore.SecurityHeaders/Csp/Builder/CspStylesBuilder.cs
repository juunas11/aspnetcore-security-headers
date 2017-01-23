using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to CSS.
    /// </summary>
    public class CspStylesBuilder
    {
        private readonly CspStyleSrcOptions _options = new CspStyleSrcOptions();

        /// <summary>
        /// Block all CSS.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow CSS from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow CSS from the given
        /// <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow CSS from anywhere, except
        /// data:, blob:, and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow inline CSS.
        /// Cannot be enabled together with AddNonce.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilder AllowUnsafeInline()
        {
            _options.AllowUnsafeInline = true;
            return this;
        }

        /// <summary>
        /// Generates a random nonce for each request and
        /// adds it to the CSP header. Allows inline styles that
        /// have the nonce attribute set to the random value on
        /// the script element.
        /// Note that you must call AddCsp() on the service collection
        /// in ConfigureServices() to add the necessary dependencies.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilder AddNonce()
        {
            _options.AddNonce = true;
            return this;
        }

        /// <summary>
        /// Allow CSS only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspStyleSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}