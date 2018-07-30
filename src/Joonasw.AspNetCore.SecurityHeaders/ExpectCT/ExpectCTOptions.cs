using System;

namespace Joonasw.AspNetCore.SecurityHeaders.ExpectCT
{
    /// <summary>
    /// Options for the Expect-CT Header
    /// </summary>
    public class ExpectCTOptions
    {
        public ExpectCTOptions()
        {
            
        }

        /// <summary>
        /// Defines the parameters for the Expect-CT header sent to clients.
        /// NOT CURRENTLY SUPPORTED
        /// </summary>
        /// <param name="maxAge">The required max-age directive specifies the number of seconds that the browser should cache and apply the received policy for, whether enforced or report-only.</param>
        /// <param name="reportUri">the report-uri directive specifies where the browser should send reports if it does not receive valid CT information. This is specified as an absolute URI.</param>
        /// <param name="enforce">The optional enforce directive controls whether the browser should enforce the policy or treat it as report-only mode. The directive has no value so you simply include it or not depending on whether or not you want the browser to enforce the policy or just report on it.</param>
        public ExpectCTOptions(TimeSpan maxAge, string reportUri, bool enforce = false)
        {
            MaxAge = maxAge;
            Enforce = enforce;
            ReportUri = reportUri;
        }

        /// <summary>
        /// Gets the maxAge browsers should remember that
        /// this domain should only be accessed over HTTPS.
        /// </summary>
        public TimeSpan MaxAge { get; set; } = TimeSpan.FromDays(30);

        /// <summary>
        /// Gets the maxAge browsers should remember
        /// this domain should only be accessed over HTTPS,
        /// in seconds.
        /// </summary>
        public int DurationSeconds => (int)MaxAge.TotalSeconds;

        /// <summary>
        /// Gets if this rule should apply to the current host.
        /// </summary>
        public bool Enforce { get; set; }

        /// <summary>
        /// Gets if this domain should be allowed to be
        /// added to preload lists in browsers.
        /// </summary>
        public string ReportUri { get; set; }

        public string HeaderValue
        {
            get
            {
                var value = string.Empty;

                if (Enforce)
                {
                    value += "enforce";
                }

                value += ";" + "max-age=" + DurationSeconds;

                if (ReportUri != null)
                {
                    value += "; report-uri=\"" + ReportUri + "\"";
                }

                return value;
            }
        }
    }
}
