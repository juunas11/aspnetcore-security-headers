namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyMagnetometerOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyMagnetometerOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.Magnetometer.DefaultValue()) { }
    }
}