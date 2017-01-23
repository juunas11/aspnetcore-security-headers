using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to images.
    /// </summary>
    public class CspImageBuilder
    {
        private readonly CspImgSrcOptions _options = new CspImgSrcOptions();

        /// <summary>
        /// Block all images.
        /// </summary>
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow images from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspImageBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow images from the given
        /// <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspImageBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow images from anywhere, except
        /// data:, blob:, and filesystem: schemes.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspImageBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Allow images over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspImageBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        /// <summary>
        /// Allow data: scheme embedding of images.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspImageBuilder DataScheme()
        {
            _options.AllowDataScheme = true;
            return this;
        }

        public CspImgSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}