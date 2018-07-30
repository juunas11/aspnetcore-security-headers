namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicySpeakerOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicySpeakerOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValues.Speaker.DefaultValue()) { }
    }
}