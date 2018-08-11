namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyPushOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyPushOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Push.DefaultValue();
        }
    }
}