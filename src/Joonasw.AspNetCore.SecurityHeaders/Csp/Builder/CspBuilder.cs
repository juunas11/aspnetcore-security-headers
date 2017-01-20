using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspBuilder
    {
        private readonly CspOptions _options = new CspOptions();
        private readonly CspSandboxBuilder _sandboxBuilder = new CspSandboxBuilder();
        public CspScriptsBuilder AllowScripts { get; } = new CspScriptsBuilder();
        public CspStylesBuilder AllowStyles { get; } = new CspStylesBuilder();
        public CspDefaultBuilder ByDefaultAllow { get; } = new CspDefaultBuilder();
        public CspChildBuilder AllowChildren { get; } = new CspChildBuilder();
        public CspImageBuilder AllowImages { get; } = new CspImageBuilder();
        public CspConnectionBuilder AllowConnections { get; } = new CspConnectionBuilder();
        public CspFontsBuilder AllowFonts { get; } = new CspFontsBuilder();
        public CspObjectsBuilder AllowObjects { get; } = new CspObjectsBuilder();
        public CspMediaBuilder AllowAudioAndVideo { get; } = new CspMediaBuilder();
        public CspFormActionBuilder AllowFormActions { get; } = new CspFormActionBuilder();
        public CspFrameAncestorsBuilder AllowFraming { get; } = new CspFrameAncestorsBuilder();
        public CspPluginTypesBuilder AllowPlugins { get; } = new CspPluginTypesBuilder();
        
        public CspSandboxBuilder EnableSandbox()
        {
            _options.EnableSandbox = true;
            return _sandboxBuilder;
        }
        
        public void SetReportOnly()
        {
            _options.ReportOnly = true;
        }

        public void ReportViolationsTo(string uri)
        {
            _options.ReportUri = uri;
        }

        public CspOptions BuildCspOptions()
        {
            _options.ScriptSrc = AllowScripts.BuildOptions();
            _options.StyleSrc = AllowStyles.BuildOptions();
            _options.ChildSrc = AllowChildren.BuildOptions();
            _options.ConnectSrc = AllowConnections.BuildOptions();
            _options.DefaultSrc = ByDefaultAllow.BuildOptions();
            _options.FontSrc = AllowFonts.BuildOptions();
            _options.FormAction = AllowFormActions.BuildOptions();
            _options.FrameAncestors = AllowFraming.BuildOptions();
            _options.ImgSrc = AllowImages.BuildOptions();
            _options.MediaSrc = AllowAudioAndVideo.BuildOptions();
            _options.ObjectSrc = AllowObjects.BuildOptions();
            _options.PluginTypes = AllowPlugins.BuildOptions();
            _options.Sandbox = _sandboxBuilder.BuildOptions();
            return _options;
        }
    }
}