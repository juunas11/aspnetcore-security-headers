namespace Joonasw.AspNetCore.SecurityHeaders.Hpkp.Builder
{
    /// <summary>
    /// Builder for building HTTP
    /// Public Key Pins rules.
    /// </summary>
    public class HpkpBuilder
    {
        private readonly HpkpOptions _options = new HpkpOptions();

        /// <summary>
        /// Sets how long the public keys will be cached
        /// in users' browsers in seconds. Decide this carefully,
        /// as the rule is quite hard for normal users to remove
        /// from cache if something were to go wrong during
        /// this period.
        /// </summary>
        /// <param name="seconds">The caching duration in seconds.</param>
        /// <returns>The builder for call chaining</returns>
        public HpkpBuilder UseMaxAgeSeconds(int seconds)
        {
            _options.MaxAgeSeconds = seconds;
            return this;
        }

        /// <summary>
        /// Adds a given SHA-256 public key hash to the header.
        /// The hash can be gotten from any certificate in the
        /// certificate chain for your certificate. This way
        /// you can either pin your specific certificate, a middle
        /// certificate, or even the root certificate.
        /// </summary>
        /// <param name="pin">The SHA-256 hash of one of the certificates thumbprints.</param>
        /// <returns>The builder for call chaining</returns>
        public HpkpBuilder AddSha256Pin(string pin)
        {
            _options.Pins.Add("pin-sha256=\"" + pin + "\"");
            return this;
        }

        /// <summary>
        /// Enables this rule for all subdomains of the
        /// current domain as well. Be very careful with
        /// this rule, as you must be sure the given keys
        /// will be used on all future subdomains.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public HpkpBuilder IncludeSubDomains()
        {
            _options.IncludeSubDomains = true;
            return this;
        }

        /// <summary>
        /// Sets the pinning to report-only mode.
        /// Invalid certificates are not blocked, but
        /// you will receive reports for violations.
        /// Excellent for testing settings.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public HpkpBuilder SetReportOnly()
        {
            _options.ReportOnly = true;
            return this;
        }

        /// <summary>
        /// The URI to where violations should be reported to.
        /// Can be a relative or absolute URL.
        /// </summary>
        /// <param name="uri">The URL where violations are reported to.</param>
        /// <returns>The builder for call chaining</returns>
        public HpkpBuilder ReportViolationsTo(string uri)
        {
            _options.ReportUri = uri;
            return this;
        }

        public HpkpOptions BuildHpkpOptions()
        {
            return _options;
        }
    }
}