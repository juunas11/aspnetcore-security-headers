using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspBuilder
    {
        private readonly CspOptions _options = new CspOptions();
        private readonly CspSandboxBuilder _sandboxBuilder = new CspSandboxBuilder();
        /// <summary>
        /// Set up rules for JavaScript.
        /// </summary>
        public CspScriptsBuilder AllowScripts { get; } = new CspScriptsBuilder();
        /// <summary>
        /// Set up rules for CSS.
        /// </summary>
        public CspStylesBuilder AllowStyles { get; } = new CspStylesBuilder();
        /// <summary>
        /// Set up default rules for resources for which no rules exist.
        /// </summary>
        public CspDefaultBuilder ByDefaultAllow { get; } = new CspDefaultBuilder();
        /// <summary>
        /// Set up rules for embedded content in e.g. iframes.
        /// </summary>
        public CspChildBuilder AllowChildren { get; } = new CspChildBuilder();
        /// <summary>
        /// Set up rules for images.
        /// </summary>
        public CspImageBuilder AllowImages { get; } = new CspImageBuilder();
        /// <summary>
        /// Set up rules for AJAX, WebSockets and EventSource.
        /// </summary>
        public CspConnectionBuilder AllowConnections { get; } = new CspConnectionBuilder();
        /// <summary>
        /// Set up rules for fonts.
        /// </summary>
        public CspFontsBuilder AllowFonts { get; } = new CspFontsBuilder();
        /// <summary>
        /// Set up rules for audio and video in e.g. HTML5 audio and video elements.
        /// </summary>
        public CspMediaBuilder AllowAudioAndVideo { get; } = new CspMediaBuilder();
        /// <summary>
        /// Set up rules for form action targets.
        /// </summary>
        public CspFormActionBuilder AllowFormActions { get; } = new CspFormActionBuilder();
        /// <summary>
        /// Set up rules for where this app can be embedded.
        /// </summary>
        public CspFrameAncestorsBuilder AllowFraming { get; } = new CspFrameAncestorsBuilder();
        /// <summary>
        /// Set up rules for plugins in e.g. &lt;object&gt; elements.
        /// </summary>
        public CspPluginBuilder AllowPlugins { get; } = new CspPluginBuilder();
        
        /// <summary>
        /// Enables sandboxing of the app in the browser.
        /// </summary>
        /// <returns>Builder for setting up exceptions to sandboxing.</returns>
        public CspSandboxBuilder EnableSandbox()
        {
            _options.EnableSandbox = true;
            return _sandboxBuilder;
        }
        
        /// <summary>
        /// Sets the CSP policy to Report-Only.
        /// Nothing is blocked, violations are only reported.
        /// Very useful when testing policies.
        /// </summary>
        public void SetReportOnly()
        {
            _options.ReportOnly = true;
        }

        /// <summary>
        /// Sets the URL where violation reports are sent.
        /// </summary>
        /// <param name="uri">The URL where violation reports should be sent.</param>
        public void ReportViolationsTo(string uri)
        {
            if(uri == null) throw new ArgumentNullException(nameof(uri));
            if(uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

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
            Tuple<CspObjectSrcOptions, CspPluginTypesOptions> pluginOptions = AllowPlugins.BuildOptions();
            _options.ObjectSrc = pluginOptions.Item1;
            _options.PluginTypes = pluginOptions.Item2;
            _options.Sandbox = _sandboxBuilder.BuildOptions();
            return _options;
        }
    }
}