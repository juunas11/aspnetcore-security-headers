namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyVrOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyVrOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.Vr.DefaultValue()) { }
    }
}