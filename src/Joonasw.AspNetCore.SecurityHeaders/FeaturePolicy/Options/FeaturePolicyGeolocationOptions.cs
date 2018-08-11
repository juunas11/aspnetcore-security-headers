namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyGeolocationOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyGeolocationOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Geolocation.DefaultValue();
        }
    }
}
