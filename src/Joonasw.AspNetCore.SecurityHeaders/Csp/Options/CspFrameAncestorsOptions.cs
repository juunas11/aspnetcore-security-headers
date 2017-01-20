using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspFrameAncestorsOptions
    {
        public ICollection<string> AllowedSources { get; set; }
        public bool AllowNone { get; set; }

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
                foreach (string allowedSource in AllowedSources)
                {
                    parts.Add(allowedSource);
                }
            }
            if (parts.Count == 0)
            {
                return string.Empty;
            }
            return "frame-ancestors " + string.Join(" ", parts);
        }
    }
}