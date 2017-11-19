using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy rules
    /// related to Worker, SharedWorker and ServiceWorker script sources.
    /// </summary>
    public class CspWorkerBuilder
    {
        private readonly CspWorkerSrcOptions _options = new CspWorkerSrcOptions();

        /// <summary>
        /// Block all Worker, SharedWorker or ServiceWorker sources.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow Worker, SharedWorker or ServiceWorker sources
        /// from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspWorkerBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow Worker, SharedWorker or ServiceWorker sources
        /// from the given <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspWorkerBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow Worker, SharedWorker or ServiceWorker sources
        /// from anywhere, except data:, blob:,
        /// and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspWorkerBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow Worker, SharedWorker or ServiceWorker sources
        /// only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspWorkerBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspWorkerSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}