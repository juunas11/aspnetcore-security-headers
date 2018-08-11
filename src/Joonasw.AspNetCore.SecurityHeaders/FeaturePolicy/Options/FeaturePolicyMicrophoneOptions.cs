namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyMicrophoneOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyMicrophoneOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Microphone.DefaultValue();
        }
    }
}