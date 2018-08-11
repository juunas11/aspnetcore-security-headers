using System;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    public class FeaturePolicyPushBuilder : IFeaturePolicyBuilder<FeaturePolicyPushBuilder>
    {
        private readonly FeaturePolicyPushOptions _options = new FeaturePolicyPushOptions();

        /// <inheritdoc />
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        /// <inheritdoc />
        public FeaturePolicyPushBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyPushBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        /// <inheritdoc />
        public FeaturePolicyPushBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedOrigins.Add(uri);
            return this;
        }

        internal FeaturePolicyPushOptions BuildOptions()
        {
            return _options;
        }
    }
}
