namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyVibrateOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyVibrateOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Vibrate.DefaultValue();
        }
    }
}