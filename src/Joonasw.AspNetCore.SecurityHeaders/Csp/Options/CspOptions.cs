using System;
using System.Collections.Generic;
using System.Linq;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspOptions
    {
        public bool ReportOnly { get; set; }
        public CspScriptSrcOptions ScriptSrc { get; set; }
        public CspStyleSrcOptions StyleSrc { get; set; }
        public CspDefaultSrcOptions DefaultSrc { get; set; }
        public CspChildSrcOptions ChildSrc { get; set; }
        public CspConnectSrcOptions ConnectSrc { get; set; }
        public CspFontSrcOptions FontSrc { get; set; }
        public CspFormActionOptions FormAction { get; set; }
        public CspImgSrcOptions ImgSrc { get; set; }
        public CspMediaSrcOptions MediaSrc { get; set; }
        public CspObjectSrcOptions ObjectSrc { get; set; }
        public CspFrameAncestorsOptions FrameAncestors { get; set; }
        public CspPluginTypesOptions PluginTypes { get; set; }
        public bool EnableSandbox { get; set; }
        public CspSandboxOptions Sandbox { get; set; }
        public string ReportUri { get; set; }

        public CspOptions()
        {
            ScriptSrc = new CspScriptSrcOptions();
            StyleSrc = new CspStyleSrcOptions();
            DefaultSrc = new CspDefaultSrcOptions();
            ChildSrc = new CspChildSrcOptions();
            ConnectSrc = new CspConnectSrcOptions();
            FontSrc = new CspFontSrcOptions();
            FormAction = new CspFormActionOptions();
            ImgSrc = new CspImgSrcOptions();
            MediaSrc = new CspMediaSrcOptions();
            ObjectSrc = new CspObjectSrcOptions();
            FrameAncestors = new CspFrameAncestorsOptions();
            PluginTypes = new CspPluginTypesOptions();
            Sandbox = new CspSandboxOptions();
        }

        public Tuple<string, string> ToString(CspNonceService nonceService)
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
                DefaultSrc.ToString(nonceService),
                ScriptSrc.ToString(nonceService),
                StyleSrc.ToString(nonceService),
                ChildSrc.ToString(nonceService),
                ConnectSrc.ToString(nonceService),
                FontSrc.ToString(nonceService),
                FormAction.ToString(nonceService),
                ImgSrc.ToString(nonceService),
                MediaSrc.ToString(nonceService),
                ObjectSrc.ToString(nonceService),
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