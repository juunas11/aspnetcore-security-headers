namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public class FeaturePolicyMidiOptions : FeaturePolicyOptionsBase
    {
        public FeaturePolicyMidiOptions() 
            : base(FeaturePolicyOptions.FeaturePolicyValues.Midi.DefaultValue()) { }
    }
}