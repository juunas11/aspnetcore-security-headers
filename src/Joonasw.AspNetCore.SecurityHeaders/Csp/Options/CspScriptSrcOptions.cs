using System;
using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspScriptSrcOptions : CspSrcOptionsBase
    {
        public bool AddNonce { get; set; }
        public bool AddSha256 { get; set; }
        public bool AllowUnsafeEval { get; set; }
        public bool AllowUnsafeInline { get; set; }
        /// <summary>
        /// Allow scripts that have been loaded with
        /// a trusted hash/nonce to load additional
        /// scripts.
        /// This enabled a &quot;strict&quot; mode
        /// for scripts, requiring a hash or nonce
        /// on all of them.
        /// </summary>
        public bool StrictDynamic { get; set; }
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
            if (StrictDynamic)
            {
                parts.Add("'strict-dynamic'");
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
                        "Sha256 service was not found, it needs to be added to the service collection");
                }
                sha256Service.GetShaScripts().ForEach(s=>
                    parts.Add($"'sha256-{s}'"));
            }
            if (AllowUnsafeEval)
            {
                parts.Add("'unsafe-eval'");
            }
            if (AllowUnsafeInline)
            {
                parts.Add("'unsafe-inline'");
            }
            if (StrictDynamic)
            {
                parts.Add("'strict-dynamic'");
            }
            return parts;
        }
    }
}
