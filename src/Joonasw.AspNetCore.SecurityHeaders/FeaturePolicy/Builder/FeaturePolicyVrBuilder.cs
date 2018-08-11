using System;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    public class FeaturePolicyVrBuilder : IFeaturePolicyBuilder<FeaturePolicyVrBuilder>
    {
        private readonly FeaturePolicyVrOptions _options = new FeaturePolicyVrOptions();

        /// <inheritdoc />
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <inheritdoc />
        public FeaturePolicyVrBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyVrBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyVrBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedOrigins.Add(uri);
            return this;
        }

        internal FeaturePolicyVrOptions BuildOptions()
        {
            return _options;
        }
    }
}
