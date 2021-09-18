using System;
using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspStyleSrcOptions : CspSrcOptionsBase
    {
        public bool AddSha256 { get; set; }
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
                if (nonceService == null)
                {
                    throw new ArgumentNullException(
                        nameof(nonceService),
                        "Nonce service was not found, it needs to be added to the service collection");
                }
                parts.Add($"'nonce-{nonceService.GetNonce()}'");
            }
            if (AllowUnsafeInline)
            {
                parts.Add("'unsafe-inline'");
            }
            return parts;
        }
        protected override ICollection<string> GetParts(ICspSha256Service sha256Service)
        {
            ICollection<string> parts = base.GetParts(sha256Service);
            if (AddSha256)
            {
                if (sha256Service == null)
                {
                    throw new ArgumentNullException(
                        nameof(sha256Service),
                        "sha256 service was not found, it needs to be added to the service collection");
                }
                sha256Service.GetShaStyles().ForEach(s=>parts.Add($"'sha256-{s}'"));
            }
            if (AllowUnsafeInline)
            {
                parts.Add("'unsafe-inline'");
            }
            return parts;
        }
    }
}
