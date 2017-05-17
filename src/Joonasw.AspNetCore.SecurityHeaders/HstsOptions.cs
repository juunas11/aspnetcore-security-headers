using System;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    /// <summary>
    /// Options for the HTTP Strict Transport Security header.
    /// </summary>
    public class HstsOptions
    {
        public HstsOptions(TimeSpan duration, bool includeSubDomains = false, bool preload = false)
        {
            Duration = duration;
            IncludeSubDomains = includeSubDomains;
            Preload = preload;
        }

        /// <summary>
        /// Gets the duration browsers should remember that
        /// this domain should only be accessed over HTTPS.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Gets the duration browsers should remember
        /// this domain should only be accessed over HTTPS,
        /// in seconds.
        /// </summary>
        public int DurationSeconds => (int) Duration.TotalSeconds;

        /// <summary>
        /// Gets if this rule also applies to any subdomains.
        /// </summary>
        public bool IncludeSubDomains { get; }

        /// <summary>
        /// Gets if this domain should be allowed to be
        /// added to preload lists in browsers.
        /// </summary>
        public bool Preload { get; }
    }
}