using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Hpkp.Options
{
    public class HpkpOptions
    {
        public int MaxAgeSeconds { get; set; }
        public IList<string> Pins { get; set; } = new List<string>();
        public bool IncludeSubDomains { get; set; }
        public bool ReportOnly { get; set; }
        public string ReportUri { get; set; }

        public string HeaderName
        {
            get { return ""; }
        }

        public string HeaderValue
        {
            get { return ""; }
        }
    }
}