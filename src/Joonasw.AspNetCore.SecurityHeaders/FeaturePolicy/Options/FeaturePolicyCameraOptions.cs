namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyCameraOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyCameraOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.Camera.DefaultValue()) { }
    }
}