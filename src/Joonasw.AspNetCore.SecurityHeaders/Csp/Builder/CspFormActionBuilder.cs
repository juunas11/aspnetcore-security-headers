using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to form action targets.
    /// </summary>
    public class CspFormActionBuilder
    {
        private readonly CspFormActionOptions _options = new CspFormActionOptions();

        /// <summary>
        /// Allow form submissions to current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFormActionBuilder ToSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow form submissions to the given
        /// <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The builder for call chaining</returns>
        public CspFormActionBuilder To(string uri)
        {
            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow form submissions anywhere.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFormActionBuilder ToAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Block form submissions.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public void ToNowhere()
        {
            _options.AllowNone = true;
        }

        /// <summary>
        /// Allow form submissions only over secure
        /// connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspFormActionBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspFormActionOptions BuildOptions()
        {
            return _options;
        }
    }
}