namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyMagnetometerOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyMagnetometerOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValues.Magnetometer.DefaultValue()) { }
    }
}