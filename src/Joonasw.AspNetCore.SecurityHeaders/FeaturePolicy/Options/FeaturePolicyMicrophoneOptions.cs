namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyMicrophoneOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyMicrophoneOptions()
            : base(FeaturePolicyOptions.FeaturePolicyValue.Microphone.DefaultValue()) { }
    }
}