namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyPushOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyPushOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValues.Push.DefaultValue()) { }
    }
}