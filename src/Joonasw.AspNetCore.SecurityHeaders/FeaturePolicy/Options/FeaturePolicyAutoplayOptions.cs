namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyAutoplayOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyAutoplayOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Autoplay.DefaultValue();
        }
    }
}