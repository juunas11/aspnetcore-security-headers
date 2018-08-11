namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyEncryptedMediaOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyEncryptedMediaOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.EncryptedMedia.DefaultValue()) { }
    }
}