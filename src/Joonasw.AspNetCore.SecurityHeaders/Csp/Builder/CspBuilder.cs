using System;
using System.Threading.Tasks;
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
        /// Set up rules for embedded content in e.g. iframes.  This has been dropped from web standards and replaced with specific rules for frames and workers
        /// </summary>
        [Obsolete("Has been replaced with AllowFrames and AllowWorkers")]
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
        /// Set up rules for frames and iframes.
        /// </summary>
        public CspFrameBuilder AllowFrames { get; } = new CspFrameBuilder();
        /// <summary>
        /// Set up rules for plugins in e.g. &lt;object&gt; elements.
        /// </summary>
        public CspPluginBuilder AllowPlugins { get; } = new CspPluginBuilder();
        /// <summary>
        /// Set up rules for workers, shared workers and service workers.
        /// </summary>
        public CspWorkerBuilder AllowWorkers { get; } = new CspWorkerBuilder();

        public Func<CspSendingHeaderContext, Task> OnSendingHeader { get; set; } = context => Task.CompletedTask;

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

        public void SetUpgradeInsecureRequests()
        {
            _options.UpgradeInsecureRequests = true;
        }

        public void SetBlockAllMixedContent()
        {
            _options.BlockAllMixedContent = true;
        }

        public CspOptions BuildCspOptions()
        {
            _options.Script = AllowScripts.BuildOptions();
            _options.Style = AllowStyles.BuildOptions();
#pragma warning disable CS0618 // Type or member is obsolete
            _options.Child = AllowChildren.BuildOptions();
#pragma warning restore CS0618 // Type or member is obsolete
            _options.Connect = AllowConnections.BuildOptions();
            _options.Default = ByDefaultAllow.BuildOptions();
            _options.Font = AllowFonts.BuildOptions();
            _options.FormAction = AllowFormActions.BuildOptions();
            _options.FrameAncestors = AllowFraming.BuildOptions();
            _options.Img = AllowImages.BuildOptions();
            _options.Media = AllowAudioAndVideo.BuildOptions();
            Tuple<CspObjectSrcOptions, CspPluginTypesOptions> pluginOptions = AllowPlugins.BuildOptions();
            _options.Object = pluginOptions.Item1;
            _options.PluginTypes = pluginOptions.Item2;
            _options.Sandbox = _sandboxBuilder.BuildOptions();
            _options.Frame = AllowFrames.BuildOptions();
            _options.Worker = AllowWorkers.BuildOptions();
            _options.OnSendingHeader = OnSendingHeader;
            return _options;
        }
    }
}