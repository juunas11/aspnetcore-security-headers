using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Joonasw.AspNetCore.SecurityHeaders.TagHelpers
{
    /// <summary>
    /// Tag helper for adding a nonce to
    /// inline scripts and styles.
    /// </summary>
    [HtmlTargetElement("script", Attributes = "asp-add-sha256")]
    [HtmlTargetElement("style", Attributes = "asp-add-sha256")]
    public class Sha256TagHelper : TagHelper
    {
        private readonly ICspSha256Service _Sha256Service;
        [HtmlAttributeName("asp-add-sha256")]
        public bool AddSha256 { get; set; }

        public Sha256TagHelper(ICspSha256Service sha256Service)
        {
            _Sha256Service = sha256Service;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (AddSha256)
            {
                var thc=output.GetChildContentAsync();thc.Wait();
                var content=thc.Result.GetContent();
                // The nonce service is created per request, so we
                // get the same nonce here as the CSP header
                if (output.TagName == "script")
                    output.Attributes.Add("sha256", _Sha256Service.AddShaScripts(content));
                else if (output.TagName == "style")
                    output.Attributes.Add("sha256", _Sha256Service.AddShaStyles(content));
                else throw new System.Exception("Unsupported tag to compute sha256");
            }
        }
    }
}
