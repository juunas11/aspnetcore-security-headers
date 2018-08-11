namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyPictureInPictureOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyPictureInPictureOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.PictureInPicture.DefaultValue();
        }
    }
}