namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyAmbientLightSensorOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyAmbientLightSensorOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.AmbientLightSensor.DefaultValue();
        }
    }
}