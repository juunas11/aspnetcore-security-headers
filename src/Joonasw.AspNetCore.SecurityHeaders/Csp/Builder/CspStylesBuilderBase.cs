using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to CSS.
    /// </summary>
    public abstract class CspStylesBuilderBase<TOptions>
        where TOptions : CspStyleSrcOptionsBase, new()
    {
        protected readonly TOptions _options = new TOptions();

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
        public CspStylesBuilderBase<TOptions> FromSelf()
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
        public CspStylesBuilderBase<TOptions> From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }
        
        /// <summary>
        /// Allow CSS with the given
        /// <paramref name="hash"/>.
        /// </summary>
        /// <param name="hash">The hash to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilderBase<TOptions> WithHash(string hash)
        {
            if (hash == null) throw new ArgumentNullException(nameof(hash));
            if (hash.Length == 0) throw new ArgumentException("Hash can't be empty", nameof(hash));
            
            _options.AllowedHashes.Add(hash);
            return this;
        }

        /// <summary>
        /// Allow CSS from anywhere, except
        /// data:, blob:, and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilderBase<TOptions> FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow inline CSS.
        /// Cannot be enabled together with AddNonce.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilderBase<TOptions> AllowUnsafeInline()
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
        public CspStylesBuilderBase<TOptions> AddNonce()
        {
            _options.AddNonce = true;
            return this;
        }

        /// <summary>
        /// Allow CSS only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspStylesBuilderBase<TOptions> OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public TOptions BuildOptions()
        {
            return _options;
        }
    }
}
