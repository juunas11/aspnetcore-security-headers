namespace Joonasw.AspNetCore.SecurityHeaders
{
    /// <summary>
    /// Options for the HTTP Strict Transport Security header.
    /// </summary>
    public class HstsOptions
    {
        /// <summary>
        /// Gets or sets the number of seconds browsers should remember that
        /// this URL should only be accessed over HTTPS. Must be set.
        /// </summary>
        public int Seconds { get; set; }
        /// <summary>
        /// Gets or sets if this rule also applies to any subdomains.
        /// Only set to true if you are willing to say that you
        /// will not need to have any HTTP subdomains.
        /// </summary>
        public bool IncludeSubDomains { get; set; }
        /// <summary>
        /// Gets or sets if this domain should be allowed to be
        /// added to preload lists in browsers. Only set to true
        /// if you are willing to hard-code this rule to modern
        /// browsers.
        /// </summary>
        public bool Preload { get; set; }
    }
}