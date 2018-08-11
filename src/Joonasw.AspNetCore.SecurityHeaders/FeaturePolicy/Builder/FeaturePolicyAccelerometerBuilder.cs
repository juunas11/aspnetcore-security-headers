using System;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    public class FeaturePolicyAccelerometerBuilder : IFeaturePolicyBuilder<FeaturePolicyAccelerometerBuilder>
    {
        private readonly FeaturePolicyAccelerometerOptions _options = new FeaturePolicyAccelerometerOptions();

        /// <inheritdoc />
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <inheritdoc />
        public FeaturePolicyAccelerometerBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyAccelerometerBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyAccelerometerBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedOrigins.Add(uri);
            return this;
        }

        internal FeaturePolicyAccelerometerOptions BuildOptions()
        {
            return _options;
        }
    }
}
