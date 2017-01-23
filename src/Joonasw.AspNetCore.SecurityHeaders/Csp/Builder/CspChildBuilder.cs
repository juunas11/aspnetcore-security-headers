using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to embedded content.
    /// </summary>
    public class CspChildBuilder
    {
        private readonly CspChildSrcOptions _options = new CspChildSrcOptions();
        
        /// <summary>
        /// Block all embedded content.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }
        
        /// <summary>
        /// Allow embedded content from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspChildBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow embedded content from given <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspChildBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow embedded content from anywhere, except
        /// data:, blob:, and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspChildBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow embedded content only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspChildBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspChildSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}