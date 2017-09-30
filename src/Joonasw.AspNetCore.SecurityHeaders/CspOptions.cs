using System;
using System.Collections.Generic;
using System.Linq;
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
        /// </summary>
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
        /// Rules for what MIME types are allowed for plugins,
        /// e.g. in &lt;object&gt; elements.
        /// </summary>
        public CspPluginTypesOptions PluginTypes { get; set; }
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

        public CspOptions()
        {
            Script = new CspScriptSrcOptions();
            Style = new CspStyleSrcOptions();
            Default = new CspDefaultSrcOptions();
            Child = new CspChildSrcOptions();
            Connect = new CspConnectSrcOptions();
            Font = new CspFontSrcOptions();
            FormAction = new CspFormActionOptions();
            Img = new CspImgSrcOptions();
            Media = new CspMediaSrcOptions();
            Object = new CspObjectSrcOptions();
            FrameAncestors = new CspFrameAncestorsOptions();
            PluginTypes = new CspPluginTypesOptions();
            Sandbox = new CspSandboxOptions();
        }

        public Tuple<string, string> ToString(ICspNonceService nonceService)
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
            ICollection<string> values = new List<string>
            {
                Default.ToString(nonceService),
                Script.ToString(nonceService),
                Style.ToString(nonceService),
                Child.ToString(nonceService),
                Connect.ToString(nonceService),
                Font.ToString(nonceService),
                FormAction.ToString(nonceService),
                Img.ToString(nonceService),
                Media.ToString(nonceService),
                Object.ToString(nonceService),
                FrameAncestors.ToString(),
                PluginTypes.ToString()
            };
            if (EnableSandbox)
            {
                values.Add(Sandbox.ToString());
            }
            if (ReportUri != null)
            {
                values.Add("report-uri " + ReportUri);
            }

            string headerValue = string.Join(";", values.Where(s => s.Length > 0));

            return new Tuple<string, string>(headerName, headerValue);
        }
    }
}