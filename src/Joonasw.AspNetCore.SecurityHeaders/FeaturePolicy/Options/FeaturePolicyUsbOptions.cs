namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyUsbOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyUsbOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.Usb.DefaultValue()) { }
    }
}