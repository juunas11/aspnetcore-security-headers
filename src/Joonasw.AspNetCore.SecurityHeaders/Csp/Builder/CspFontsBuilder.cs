using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to fonts.
    /// </summary>
    public class CspFontsBuilder
    {
        private readonly CspFontSrcOptions _options = new CspFontSrcOptions();

        /// <summary>
        /// Block all fonts.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow fonts from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFontsBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow fonts from the given
        /// <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspFontsBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow fonts from anywhere, except
        /// data:, blob:, and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFontsBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow fonts only over secure
        /// connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFontsBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspFontSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}