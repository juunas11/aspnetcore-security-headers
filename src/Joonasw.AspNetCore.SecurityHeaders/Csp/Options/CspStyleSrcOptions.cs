using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspStyleSrcOptions : CspSrcOptionsBase
    {
        public bool AddNonce { get; set; }
        public bool AllowUnsafeInline { get; set; }
        public CspStyleSrcOptions()
            : base("style-src")
        {
        }

        protected override ICollection<string> GetParts(ICspNonceService nonceService)
        {
            ICollection<string> parts = base.GetParts(nonceService);
            if (AddNonce)
            {
                parts.Add($"'nonce-{nonceService.GetNonce()}'");
            }
            if (AllowUnsafeInline)
            {
                parts.Add("'unsafe-inline'");
            }
            return parts;
        }
    }
}
