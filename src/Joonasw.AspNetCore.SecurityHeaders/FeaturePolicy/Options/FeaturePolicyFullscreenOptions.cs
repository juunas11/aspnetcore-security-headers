namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyFullscreenOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyFullscreenOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Fullscreen.DefaultValue();
        }
    }
}