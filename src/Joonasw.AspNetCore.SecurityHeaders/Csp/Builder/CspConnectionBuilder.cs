using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspConnectionBuilder
    {
        private readonly CspConnectSrcOptions _options = new CspConnectSrcOptions();

        public CspConnectionBuilder ToSelf()
        {
            _options.AllowSelf = true;
            return this;   
        }

        public CspConnectionBuilder To(string target)
        {
            _options.AllowedSources.Add(target);
            return this;
        }

        public CspConnectionBuilder ToAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspConnectionBuilder ToNowhere()
        {
            _options.AllowNone = true;
            return this;
        }

        public CspConnectionBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        internal CspConnectSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}