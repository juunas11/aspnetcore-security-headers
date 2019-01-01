using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for controlling where web manifests can be loaded from.
    /// </summary>
    public class CspManifestBuilder
    {
        private readonly CspManifestSrcOptions _options = new CspManifestSrcOptions();

        /// <summary>
        /// Allow manifests to be loaded from the current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspManifestBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow manifests to load from the given <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspManifestBuilder From(string uri)
        {
            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow manifests to load from anywhere.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspManifestBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Block all loading of manifests.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow manifests to load from secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspManifestBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspManifestSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}