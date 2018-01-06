using System;
using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspScriptSrcOptions : CspSrcOptionsBase
    {
        public bool AddNonce { get; set; }
        public bool AllowUnsafeEval { get; set; }
        public bool AllowUnsafeInline { get; set; }
        public CspScriptSrcOptions()
            : base("script-src")
        {
        }

        protected override ICollection<string> GetParts(ICspNonceService nonceService)
        {
            ICollection<string> parts = base.GetParts(nonceService);
            if (AddNonce)
            {
                if(nonceService == null)
                {
                    throw new ArgumentNullException(
                        nameof(nonceService),
                        "Nonce service was not found, it needs to be added to the service collection");
                }
                parts.Add($"'nonce-{nonceService.GetNonce()}'");
            }
            if (AllowUnsafeEval)
            {
                parts.Add("'unsafe-eval'");
            }
            if (AllowUnsafeInline)
            {
                parts.Add("'unsafe-inline'");
            }
            return parts;
        }
    }
}
