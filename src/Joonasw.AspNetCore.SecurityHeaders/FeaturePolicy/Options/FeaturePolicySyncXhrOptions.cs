namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicySyncXhrOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicySyncXhrOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.SyncXhr.DefaultValue();
        }
    }
}