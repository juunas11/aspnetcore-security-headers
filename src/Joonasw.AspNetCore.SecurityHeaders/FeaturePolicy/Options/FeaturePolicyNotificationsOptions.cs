namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyNotificationsOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyNotificationsOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Notifications.DefaultValue();
        }
    }
}