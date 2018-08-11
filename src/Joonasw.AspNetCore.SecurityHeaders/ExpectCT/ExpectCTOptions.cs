using System;
using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.ExpectCT
{
    /// <summary>
    /// Options for the Expect-CT Header
    /// </summary>
    public class ExpectCTOptions
    {
        /// <summary>
        /// Defines the parameters for the Expect-CT header with only the max-age set to 30 days.
        /// Please see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Expect-CT for support and more info
        /// </summary>
        public ExpectCTOptions()
        {

        }

        /// <summary>
        /// Defines the parameters for the Expect-CT header sent to clients.
        /// Please see https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Expect-CT for support and more info
        /// </summary>
        /// <param name="maxAge">The required max-age directive specifies the number of seconds that
        /// the browser should cache and apply the received policy for, whether enforced or report-only.</param>
        /// <param name="reportUri">the report-uri directive specifies where the browser should send reports
        /// if it does not receive valid CT information. This is specified as an absolute URI.</param>
        /// <param name="enforce">The optional enforce directive controls whether the browser should
        /// enforce the policy. Omitting this will treat it as report-only mode. The directive has no value so you simply
        /// include it or not depending on whether or not you want the browser to enforce the policy.</param>
        public ExpectCTOptions(TimeSpan maxAge, string reportUri, bool enforce = false)
        {
            MaxAge = maxAge;
            Enforce = enforce;
            ReportUri = reportUri;
        }

        /// <summary>
        /// Specifies the TimeSpan from seconds after reception of the Expect-CT header field
        /// during which the user agent should regard the host from whom the message was
        /// received as a known Expect-CT host.
        /// </summary>
        public TimeSpan MaxAge { get; set; } = TimeSpan.FromDays(30);

        /// <summary>
        /// Specifies the number of seconds after reception of the Expect-CT header field
        /// during which the user agent should regard the host from whom the message was
        /// received as a known Expect-CT host.
        /// </summary>
        public int DurationSeconds => (int)MaxAge.TotalSeconds;

        /// <summary>
        /// If true, browsers will enforce the Certificate Transparency policy and refuse future connections that violate the policy.
        /// </summary>
        public bool Enforce { get; set; }

        /// <summary>
        /// The URL where violation reports should be sent.
        /// </summary>
        public string ReportUri { get; set; }

        public string HeaderValue
        {
            get
            {
                var values = new List<string>(3)
                {
                    "max-age=" + DurationSeconds
                };

                if (Enforce)
                {
                    values.Add("enforce");
                }

                if (ReportUri != null)
                {
                    values.Add($"report-uri=\"{ReportUri}\"");
                }

                return string.Join(", ", values);
            }
        }
    }
}
