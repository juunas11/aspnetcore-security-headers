namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyUsbOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyUsbOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Usb.DefaultValue();
        }
    }
}