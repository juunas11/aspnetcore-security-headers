namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyAccelerometerOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyAccelerometerOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.Accelerometer.DefaultValue()) { }
    }
}