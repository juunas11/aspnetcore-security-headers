using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using System;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspBaseUriBuilder
    {
        private readonly CspBaseUriOptions _options = new CspBaseUriOptions();

        /// <summary>
        /// Block &lt;base&gt; element usage.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow &lt;base&gt; element value to be the
        /// current host.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspBaseUriBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow &lt;base&gt; element value to be the given
        /// URI.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspBaseUriBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow &lt;base&gt; element values from anywhere, except
        /// data:, blob:, and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspBaseUriBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Require &lt;base&gt; element values to
        /// use only HTTPS.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspBaseUriBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspBaseUriOptions BuildOptions()
        {
            return _options;
        }
    }
}
