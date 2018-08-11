namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyVrOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyVrOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Vr.DefaultValue();
        }
    }
}