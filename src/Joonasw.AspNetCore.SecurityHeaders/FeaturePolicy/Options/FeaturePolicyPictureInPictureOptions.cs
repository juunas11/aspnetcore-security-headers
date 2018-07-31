namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyPictureInPictureOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyPictureInPictureOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.PictureInPicture.DefaultValue()) { }
    }
}