using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy rules
    /// related to &lt;audio&gt; and &lt;video&gt; sources.
    /// </summary>
    public class CspMediaBuilder
    {
        private readonly CspMediaSrcOptions _options = new CspMediaSrcOptions();

        /// <summary>
        /// Block all &lt;audio&gt;
        /// and &lt;video&gt; sources.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow &lt;audio&gt; and &lt;video&gt; sources
        /// from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspMediaBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow &lt;audio&gt; and &lt;video&gt; sources
        /// from the given <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspMediaBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow &lt;audio&gt; and &lt;video&gt; sources
        /// from anywhere, except data:, blob:,
        /// and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspMediaBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow &lt;audio&gt; and &lt;video&gt; sources
        /// only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspMediaBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspMediaSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}