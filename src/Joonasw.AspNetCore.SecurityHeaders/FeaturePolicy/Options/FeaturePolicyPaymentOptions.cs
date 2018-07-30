namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyPaymentOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyPaymentOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValues.Payment.DefaultValue()) { }
    }
}