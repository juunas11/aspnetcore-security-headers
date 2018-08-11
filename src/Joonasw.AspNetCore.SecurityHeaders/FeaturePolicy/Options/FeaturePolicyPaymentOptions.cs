namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyPaymentOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyPaymentOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Payment.DefaultValue();
        }
    }
}