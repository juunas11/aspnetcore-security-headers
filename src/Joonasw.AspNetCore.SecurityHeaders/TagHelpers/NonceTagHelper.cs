using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Joonasw.AspNetCore.SecurityHeaders.TagHelpers
{
    /// <summary>
    /// Tag helper for adding a nonce to
    /// inline scripts and styles.
    /// </summary>
    [HtmlTargetElement("script", Attributes = "asp-add-nonce")]
    [HtmlTargetElement("style", Attributes = "asp-add-nonce")]
    public class NonceTagHelper : TagHelper
    {
        private readonly ICspNonceService _nonceService;
        [HtmlAttributeName("asp-add-nonce")]
        public bool AddNonce { get; set; }

        public NonceTagHelper(ICspNonceService nonceService)
        {
            _nonceService = nonceService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (AddNonce)
            {
                // The nonce service is created per request, so we
                // get the same nonce here as the CSP header
                output.Attributes.Add("nonce", _nonceService.GetNonce());
            }
        }
    }
}
