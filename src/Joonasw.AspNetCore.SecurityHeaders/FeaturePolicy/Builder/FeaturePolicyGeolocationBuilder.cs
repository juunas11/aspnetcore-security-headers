using System;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    public class FeaturePolicyGeolocationBuilder : IFeaturePolicyBuilder<FeaturePolicyGeolocationBuilder>
    {
        private readonly FeaturePolicyGeolocationOptions _options = new FeaturePolicyGeolocationOptions();

        /// <inheritdoc />
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <inheritdoc />
        public FeaturePolicyGeolocationBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyGeolocationBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyGeolocationBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedOrigins.Add(uri);
            return this;
        }

        internal FeaturePolicyGeolocationOptions BuildOptions()
        {
            return _options;
        }
    }
}
