namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyGeolocationOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyGeolocationOptions() 
            : base(FeaturePolicyOptions.FeaturePolicyValue.Geolocation.DefaultValue()) { }
    }
}
