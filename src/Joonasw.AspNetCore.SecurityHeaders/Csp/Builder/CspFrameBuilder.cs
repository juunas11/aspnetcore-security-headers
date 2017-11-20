using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy rules
    /// related to &lt;frame&gt; and &lt;iframe&gt; sources.
    /// </summary>
    public class CspFrameBuilder
    {
        private readonly CspFrameSrcOptions _options = new CspFrameSrcOptions();

        /// <summary>
        /// Block all &lt;frame&gt;
        /// and &lt;iframe&gt; sources.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow &lt;frame&gt; and &lt;iframe&gt; sources
        /// from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFrameBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow &lt;frame&gt; and &lt;iframe&gt; sources
        /// from the given <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspFrameBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow &lt;frame&gt; and &lt;iframe&gt; sources
        /// from anywhere, except data:, blob:,
        /// and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFrameBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow &lt;frame&gt; and &lt;iframe&gt; sources
        /// only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFrameBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspFrameSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}