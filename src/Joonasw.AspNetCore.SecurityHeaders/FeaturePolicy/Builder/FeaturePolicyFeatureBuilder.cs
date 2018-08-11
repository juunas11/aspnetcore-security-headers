using System;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    public class FeaturePolicyFeatureBuilder<TOptions> : IFeaturePolicyFeatureBuilder<FeaturePolicyFeatureBuilder<TOptions>>
        where TOptions : FeaturePolicyOptionsBase, new()
    {
        private readonly FeaturePolicyOptionsBase _options;

        public FeaturePolicyFeatureBuilder()
        {
            _options = new TOptions();
        }

        /// <inheritdoc />
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <inheritdoc />
        public FeaturePolicyFeatureBuilder<TOptions> FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyFeatureBuilder<TOptions> FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyFeatureBuilder<TOptions> From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedOrigins.Add(uri);
            return this;
        }

        internal FeaturePolicyOptionsBase BuildOptions()
        {
            return _options;
        }
    }
}
