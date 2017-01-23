using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to AJAX, WebSockets and EventSource.
    /// </summary>
    public class CspConnectionBuilder
    {
        private readonly CspConnectSrcOptions _options = new CspConnectSrcOptions();

        /// <summary>
        /// Allow AJAX, WebSockets and EventSource
        /// to the current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspConnectionBuilder ToSelf()
        {
            _options.AllowSelf = true;
            return this;   
        }

        /// <summary>
        /// Allow AJAX, WebSockets and EventSource
        /// to the given <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspConnectionBuilder To(string uri)
        {
            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow AJAX, WebSockets and EventSource
        /// to anywhere.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspConnectionBuilder ToAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Block all usage of AJAX, WebSockets and
        /// EventSource.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public void ToNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow AJAX, WebSockets and EventSource
        /// only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspConnectionBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspConnectSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}