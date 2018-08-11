namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyFullscreenOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyFullscreenOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.Fullscreen.DefaultValue()) { }
    }
}