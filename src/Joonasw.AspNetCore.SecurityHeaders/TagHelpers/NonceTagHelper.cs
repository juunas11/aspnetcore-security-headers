using Joonasw.AspNetCore.SecurityHeaders.Csp;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Joonasw.AspNetCore.SecurityHeaders.TagHelpers
{
    [HtmlTargetElement("script", Attributes = "add-nonce")]
    [HtmlTargetElement("style", Attributes = "add-nonce")]
    public class NonceTagHelper : TagHelper
    {
        private readonly CspNonceService _nonceService;
        public bool AddNonce { get; set; }

        public NonceTagHelper(CspNonceService nonceService)
        {
            _nonceService = nonceService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (AddNonce)
            {
                output.Attributes.Add("nonce", _nonceService.GetNonce());
            }
        }
    }
}
