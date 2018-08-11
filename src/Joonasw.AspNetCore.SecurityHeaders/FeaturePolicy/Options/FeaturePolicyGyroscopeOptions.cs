namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyGyroscopeOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyGyroscopeOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Gyroscope.DefaultValue();
        }
    }
}