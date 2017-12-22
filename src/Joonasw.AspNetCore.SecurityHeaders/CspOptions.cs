using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    public class CspOptions
    {
        /// <summary>
        /// If true, violations are not blocked, only reported.
        /// </summary>
        public bool ReportOnly { get; set; }
        /// <summary>
        /// Rules to apply for JavaScript.
        /// </summary>
        public CspScriptSrcOptions Script { get; set; }
        /// <summary>
        /// Rules to apply for CSS.
        /// </summary>
        public CspStyleSrcOptions Style { get; set; }
        /// <summary>
        /// Default rules to apply if no directive is
        /// present for the resource type.
        /// </summary>
        public CspDefaultSrcOptions Default { get; set; }
        /// <summary>
        /// Rules to apply for web workers and nested frames.
        /// This has been removed from web standards and
        /// replaced with specific rules for frames and workers.
        /// </summary>
        [Obsolete("Replaced with Frame and Worker")]
        public CspChildSrcOptions Child { get; set; }
        /// <summary>
        /// Rules to apply for AJAX, WebSockets and EventSource.
        /// </summary>
        public CspConnectSrcOptions Connect { get; set; }
        /// <summary>
        /// Rules to apply for fonts.
        /// </summary>
        public CspFontSrcOptions Font { get; set; }
        /// <summary>
        /// Rules to apply for forms.
        /// </summary>
        public CspFormActionOptions FormAction { get; set; }
        /// <summary>
        /// Rules to apply for images.
        /// </summary>
        public CspImgSrcOptions Img { get; set; }
        /// <summary>
        /// Rules to apply for audio and video, e.g.
        /// &lt;audio&gt; and &lt;video&gt; elements.
        /// </summary>
        public CspMediaSrcOptions Media { get; set; }
        /// <summary>
        /// Rules to apply for &lt;object&gt;, &lt;embed&gt; and
        /// &lt;applet&gt; elements.
        /// </summary>
        public CspObjectSrcOptions Object { get; set; }
        /// <summary>
        /// Rules to apply for other apps wishing to embed this app,
        /// e.g. in an iframe.
        /// </summary>
        public CspFrameAncestorsOptions FrameAncestors { get; set; }
        /// <summary>
        /// Rules to apply for &lt;frame&gt; and &lt;iframe&gt; sources.
        /// </summary>
        public CspFrameSrcOptions Frame { get; set; }
        /// <summary>
        /// Rules for what MIME types are allowed for plugins,
        /// e.g. in &lt;object&gt; elements.
        /// </summary>
        public CspPluginTypesOptions PluginTypes { get; set; }
        /// <summary>
        /// Rules to apply for Worker, SharedWorker and
        /// ServiceWorker script sources.
        /// </summary>
        public CspWorkerSrcOptions Worker { get; set; }
        /// <summary>
        /// If true, the browser will execute the page in a
        /// tightly controlled sandbox.
        /// Similar to the sandbox attribute on iframes.
        /// </summary>
        public bool EnableSandbox { get; set; }
        /// <summary>
        /// Exceptions for sandboxing. Which things the page
        /// can do.
        /// </summary>
        public CspSandboxOptions Sandbox { get; set; }
        /// <summary>
        /// The URL where violation reports should be sent.
        /// </summary>
        public string ReportUri { get; set; }

        public bool IsNonceNeeded => Script.AddNonce || Style.AddNonce;

        /// <summary>
        /// If true, the upgrade-insecure-requests directive
        /// will be included in the policy.
        /// It will force the browser to download resources
        /// declared with insecure URLs (http://) through
        /// HTTPS instead. Note this does not replace
        /// HSTS, it only applies to content on the page.
        /// </summary>
        public bool UpgradeInsecureRequests { get; set; }

        /// <summary>
        /// If true, the block-all-mixed-content directive
        /// will be included in the policy.
        /// Prevents loading of resources over an insecure
        /// channel.
        /// </summary>
        public bool BlockAllMixedContent { get; set; }

        /// <summary>
        /// A delegate assigned to this property will be invoked when the related method
        /// is called.
        /// </summary>
        public Func<CspSendingHeaderContext, Task> OnSendingHeader { get; set; } = context => Task.CompletedTask;

        /// <summary>
        /// Implements the interface method by invoking the related delegate method.
        /// </summary>
        /// <param name="context"></param>
        public virtual Task SendingHeader(CspSendingHeaderContext context) => OnSendingHeader(context);

        public CspOptions()
        {
            Script = new CspScriptSrcOptions();
            Style = new CspStyleSrcOptions();
            Default = new CspDefaultSrcOptions();
#pragma warning disable CS0618 // Type or member is obsolete
            Child = new CspChildSrcOptions();
#pragma warning restore CS0618 // Type or member is obsolete
            Connect = new CspConnectSrcOptions();
            Font = new CspFontSrcOptions();
            FormAction = new CspFormActionOptions();
            Img = new CspImgSrcOptions();
            Media = new CspMediaSrcOptions();
            Object = new CspObjectSrcOptions();
            FrameAncestors = new CspFrameAncestorsOptions();
            PluginTypes = new CspPluginTypesOptions();
            Sandbox = new CspSandboxOptions();
            Frame = new CspFrameSrcOptions();
            Worker = new CspWorkerSrcOptions();
        }

        public (string headerName, string headerValue) ToString(ICspNonceService nonceService)
        {
            string headerName;
            if (ReportOnly)
            {
                headerName = "Content-Security-Policy-Report-Only";
            }
            else
            {
                headerName = "Content-Security-Policy";
            }
            var values = new List<string>
            {
                Default.ToString(nonceService),
                Script.ToString(nonceService),
                Style.ToString(nonceService),
#pragma warning disable CS0618 // Type or member is obsolete
                Child.ToString(nonceService),
#pragma warning restore CS0618 // Type or member is obsolete
                Connect.ToString(nonceService),
                Font.ToString(nonceService),
                FormAction.ToString(nonceService),
                Img.ToString(nonceService),
                Media.ToString(nonceService),
                Object.ToString(nonceService),
                FrameAncestors.ToString(),
                PluginTypes.ToString(),
                Frame.ToString(nonceService),
                Worker.ToString(nonceService)
            };
            if (BlockAllMixedContent)
            {
                values.Insert(0, "block-all-mixed-content");
            }
            if (UpgradeInsecureRequests)
            {
                values.Insert(0, "upgrade-insecure-requests");
            }
            if (EnableSandbox)
            {
                values.Add(Sandbox.ToString());
            }
            if (ReportUri != null)
            {
                values.Add("report-uri " + ReportUri);
            }

            string headerValue = string.Join(";", values.Where(s => s.Length > 0));

            return (headerName, headerValue);
        }
    }
}