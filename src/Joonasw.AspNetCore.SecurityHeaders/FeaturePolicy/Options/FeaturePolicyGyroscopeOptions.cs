namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyGyroscopeOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyGyroscopeOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValues.Gyroscope.DefaultValue()) { }
    }
}