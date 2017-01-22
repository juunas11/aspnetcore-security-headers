using Joonasw.AspNetCore.SecurityHeaders.Hpkp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Hpkp.Builder
{
    public class HpkpBuilder
    {
        private readonly HpkpOptions _options = new HpkpOptions();

        public HpkpBuilder UseMaxAgeSeconds(int seconds)
        {
            _options.MaxAgeSeconds = seconds;
            return this;
        }

        public HpkpBuilder AddSha256Pin(string pin)
        {
            _options.Pins.Add("pin-sha256=\"" + pin + "\"");
            return this;
        }

        public HpkpBuilder IncludeSubDomains()
        {
            _options.IncludeSubDomains = true;
            return this;
        }

        public HpkpBuilder SetReportOnly()
        {
            _options.ReportOnly = true;
            return this;
        }

        public HpkpBuilder ReportViolationsTo(string uri)
        {
            _options.ReportUri = uri;
            return this;
        }

        internal HpkpOptions BuildHpkpOptions()
        {
            return _options;
        }
    }
}