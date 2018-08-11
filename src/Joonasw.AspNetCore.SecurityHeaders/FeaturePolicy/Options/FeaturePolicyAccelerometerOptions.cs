namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyAccelerometerOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyAccelerometerOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Accelerometer.DefaultValue();
        }
    }
}