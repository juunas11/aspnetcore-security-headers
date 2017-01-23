using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for default fallback
    /// Content Security Policy rules.
    /// </summary>
    public class CspDefaultBuilder
    {
        private readonly CspDefaultSrcOptions _options = new CspDefaultSrcOptions();

        /// <summary>
        /// Block the resource.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow resources from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspDefaultBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow resources from the given
        /// <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspDefaultBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow resources from any source, except
        /// data:, blob:, and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspDefaultBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow resources only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspDefaultBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspDefaultSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}
