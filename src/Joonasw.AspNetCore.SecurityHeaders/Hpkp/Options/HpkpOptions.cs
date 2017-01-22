using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Hpkp.Options
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


        //Public-Key-Pins: (or Public-Key-Pins-Report-Only:)
        //pin-sha256="cUPcTAZWKaASuYWhhneDttWpY3oBAkE3h2+soZS7sWs=";
        //pin-sha256="M8HztCzM3elUxkcjR2S5P4hhyBNf6lHkmjAHKhpGPWE=";
        //max-age=5184000; includeSubDomains;
        //report-uri="https://www.example.org/hpkp-report"


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