namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicySyncXhrOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicySyncXhrOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.SyncXhr.DefaultValue()) { }
    }
}