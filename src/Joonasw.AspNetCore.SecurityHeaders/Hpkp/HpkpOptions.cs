using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Hpkp
{
    public class HpkpOptions
    {
        private const string ReportOnlyHeaderName = "Public-Key-Pins-Report-Only";
        private const string BlockingHeaderName = "Public-Key-Pins";
        public int MaxAgeSeconds { get; set; }
        public IList<string> Pins { get; set; } = new List<string>();
        public bool IncludeSubDomains { get; set; }
        public bool ReportOnly { get; set; }
        public string ReportUri { get; set; }

        public string HeaderName => ReportOnly ? ReportOnlyHeaderName : BlockingHeaderName;

        public string HeaderValue
        {
            get
            {
                string value = string.Join(";", Pins);

                value += ";" + "max-age=" + MaxAgeSeconds;

                if (IncludeSubDomains)
                {
                    value += "; includeSubDomains";
                }

                if (ReportUri != null)
                {
                    value += "; report-uri=\"" + ReportUri + "\"";
                }

                return value;
            }
        }
    }
}