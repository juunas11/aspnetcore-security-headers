using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspFrameAncestorsOptions
    {
        /// <summary>
        /// Collection of sources that can embed this app.
        /// </summary>
        public ICollection<string> AllowedSources { get; set; }
        /// <summary>
        /// Allow embedding from the same domain as the app.
        /// Equivalent to X-Frame-Options: SAMEORIGIN.
        /// </summary>
        public bool AllowSelf { get; set; }
        /// <summary>
        /// Block iframe embedding.
        /// Equivalent to X-Frame-Options: DENY.
        /// </summary>
        public bool AllowNone { get; set; }
        /// <summary>
        /// Allow loading only through secure channels.
        /// </summary>
        public bool AllowOnlyHttps { get; set; }
        /// <summary>
        /// Allows any source.
        /// </summary>
        public bool AllowAny { get; set; }

        public CspFrameAncestorsOptions()
        {
            AllowedSources = new List<string>();
        }

        public override string ToString()
        {
            ICollection<string> parts = new List<string>();

            if (AllowNone)
            {
                parts.Add("'none'");
            }
            else
            {
                if (AllowAny)
                {
                    parts.Add("*");
                }
                if (AllowSelf)
                {
                    parts.Add("'self'");
                }
                if (AllowOnlyHttps)
                {
                    parts.Add("https:");
                }

                foreach (string allowedSource in AllowedSources)
                {
                    parts.Add(allowedSource);
                }
            }

            if(parts.Count == 0)
            {
                return string.Empty;
            }

            return "frame-ancestors " + string.Join(" ", parts);
        }
    }
}