namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyFullscreenOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyFullscreenOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValues.Fullscreen.DefaultValue()) { }
    }
}