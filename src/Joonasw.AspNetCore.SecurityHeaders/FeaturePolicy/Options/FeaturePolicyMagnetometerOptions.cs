namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyMagnetometerOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyMagnetometerOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Magnetometer.DefaultValue();
        }
    }
}