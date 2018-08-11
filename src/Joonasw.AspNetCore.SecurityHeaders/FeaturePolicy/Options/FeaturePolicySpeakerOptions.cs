namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicySpeakerOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicySpeakerOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Speaker.DefaultValue();
        }
    }
}