using System;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    /// <summary>
    /// Options for the HTTP Strict Transport Security header.
    /// </summary>
    public class HstsOptions
    {
        public HstsOptions()
        {

        }

        /// <summary>
        /// Defines the parameters for the HSTS header sent
        /// to clients.
        /// </summary>
        /// <param name="duration">The amount of time the clients should remember that
        /// this domain should only be accessed over HTTPS.</param>
        /// <param name="includeSubDomains">If true, clients will also apply the rule on
        /// any subdomains of the current domain. Enable this only if you know what you are doing.
        /// False by default.</param>
        /// <param name="preload">If true, allows this rule to be built into browsers,
        /// preventing the first insecure connection. Enable this only if you know what you are doing.
        /// False by default.</param>
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
        public TimeSpan Duration { get; set; } = TimeSpan.FromDays(30);

        /// <summary>
        /// Gets the duration browsers should remember
        /// this domain should only be accessed over HTTPS,
        /// in seconds.
        /// </summary>
        public int DurationSeconds => (int)Duration.TotalSeconds;

        /// <summary>
        /// Gets if this rule also applies to any subdomains.
        /// </summary>
        public bool IncludeSubDomains { get; set; }

        /// <summary>
        /// Gets if this domain should be allowed to be
        /// added to preload lists in browsers.
        /// </summary>
        public bool Preload { get; set; }
    }
}