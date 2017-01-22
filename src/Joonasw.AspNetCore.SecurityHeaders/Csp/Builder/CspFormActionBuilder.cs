using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspFormActionBuilder
    {
        private readonly CspFormActionOptions _options = new CspFormActionOptions();

        public CspFormActionBuilder ToSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspFormActionBuilder To(string target)
        {
            _options.AllowedSources.Add(target);
            return this;
        }

        public CspFormActionBuilder ToAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspFormActionBuilder ToNowhere()
        {
            _options.AllowNone = true;
            return this;
        }

        public CspFormActionBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspFormActionOptions BuildOptions()
        {
            return _options;
        }
    }
}