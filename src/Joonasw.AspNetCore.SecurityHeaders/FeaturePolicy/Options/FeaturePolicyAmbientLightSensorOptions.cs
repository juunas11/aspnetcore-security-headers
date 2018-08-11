namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyAmbientLightSensorOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyAmbientLightSensorOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.AmbientLightSensor.DefaultValue()) { }
    }
}