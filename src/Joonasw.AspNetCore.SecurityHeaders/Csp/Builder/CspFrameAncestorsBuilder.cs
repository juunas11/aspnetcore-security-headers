using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to embedding this app.
    /// </summary>
    public class CspFrameAncestorsBuilder
    {
        private readonly CspFrameAncestorsOptions _options = new CspFrameAncestorsOptions();

        /// <summary>
        /// Deny embedding this app.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow embedding this app in itself.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFrameAncestorsBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow embedding this app in the given
        /// <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspFrameAncestorsBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow embedding this app anywhere.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFrameAncestorsBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow embedding this app only
        /// over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFrameAncestorsBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspFrameAncestorsOptions BuildOptions()
        {
            return _options;
        }
    }
}