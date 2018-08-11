namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyMidiOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyMidiOptions()
        {
            FeatureName = FeaturePolicyOptions.FeaturePolicyValue.Midi.DefaultValue();
        }
    }
}