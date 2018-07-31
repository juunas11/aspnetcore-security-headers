namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyAutoplayOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyAutoplayOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.Autoplay.DefaultValue()) { }
    }
}