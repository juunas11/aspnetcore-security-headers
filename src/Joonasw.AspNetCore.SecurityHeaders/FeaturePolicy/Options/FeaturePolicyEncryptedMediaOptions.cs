namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyEncryptedMediaOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyEncryptedMediaOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.EncryptedMedia.DefaultValue();
        }
    }
}