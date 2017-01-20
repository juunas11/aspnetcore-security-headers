using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public abstract class CspSrcOptionsBase
    {
        private readonly string _directiveName;
        public ICollection<string> AllowedSources { get; set; }
        public bool AllowSelf { get; set; }
        public bool AddNonce { get; set; }
        public bool AllowUnsafeInline { get; set; }
        public bool AllowUnsafeEval { get; set; }
        public bool AllowNone { get; set; }
        public bool AllowOnlyHttps { get; set; }
        public bool AllowDataScheme { get; set; }

        public CspSrcOptionsBase(string directiveName)
        {
            _directiveName = directiveName + " ";
            AllowedSources = new List<string>();
        }

        public string ToString(CspNonceService nonceService)
        {
            ICollection<string> parts = new List<string>();

            if (AllowNone)
            {
                parts.Add("'none'");
            }
            else
            {
                if (AllowSelf)
                {
                    parts.Add("'self'");
                }

                if (AllowOnlyHttps)
                {
                    parts.Add("https:");
                }
                if (AllowDataScheme)
                {
                    parts.Add("data:");
                }

                foreach (string allowedSource in AllowedSources)
                {
                    parts.Add(allowedSource);
                }

                if (AddNonce)
                {
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
            }

            if (parts.Count == 0)
            {
                return string.Empty;
            }
            return _directiveName + string.Join(" ", parts);
        }
    }
}