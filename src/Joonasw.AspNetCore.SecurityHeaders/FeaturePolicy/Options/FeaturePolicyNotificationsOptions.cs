namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyNotificationsOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyNotificationsOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValues.Notifications.DefaultValue()) { }
    }
}