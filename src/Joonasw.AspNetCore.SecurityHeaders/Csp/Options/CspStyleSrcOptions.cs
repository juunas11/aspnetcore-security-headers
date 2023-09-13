using System;
using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspStyleSrcOptions : CspSrcOptionsBase
    {
        public bool AddNonce { get; set; }

        public bool AllowUnsafeInline { get; set; }

        /// <summary>
        /// Collection of hashes that can be loaded.
        /// </summary>
        public ICollection<string> AllowedHashes { get; set; }

        public CspStyleSrcOptions()
            : base("style-src")
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

            if (AllowUnsafeInline)
            {
                parts.Add("'unsafe-inline'");
            }

            return parts;
        }
    }
}
