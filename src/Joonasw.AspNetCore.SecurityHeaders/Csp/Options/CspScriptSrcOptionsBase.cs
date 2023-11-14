using System;
using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public abstract class CspScriptSrcOptionsBase : CspSrcOptionsBase
    {
        public bool AddNonce { get; set; }

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

        /// <summary>
        /// Collection of hashes that can be loaded.
        /// </summary>
        public ICollection<string> AllowedHashes { get; set; }

        protected CspScriptSrcOptionsBase(string directiveName)
            : base(directiveName)
        {
            AllowedHashes = new List<string>();
        }

        protected override ICollection<string> GetParts(ICspNonceService nonceService)
        {
            ICollection<string> parts = base.GetParts(nonceService);

            foreach (string allowedHash in AllowedHashes)
            {
                parts.Add($"'{allowedHash}'");
            }

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
