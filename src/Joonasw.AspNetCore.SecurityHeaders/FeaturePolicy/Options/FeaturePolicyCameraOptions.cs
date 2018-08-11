namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyCameraOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyCameraOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Camera.DefaultValue();
        }
    }
}