using System;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    public class FeaturePolicyOtherFeatureBuilder : IFeaturePolicyFeatureBuilder<FeaturePolicyOtherFeatureBuilder>
    {
        private readonly FeaturePolicyOtherFeatureOptions _options;

        public FeaturePolicyOtherFeatureBuilder(FeaturePolicyOtherFeatureOptions options)
        {
            _options = options;
        }

        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        public FeaturePolicyOtherFeatureBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public FeaturePolicyOtherFeatureBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public FeaturePolicyOtherFeatureBuilder From(string uri)
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
