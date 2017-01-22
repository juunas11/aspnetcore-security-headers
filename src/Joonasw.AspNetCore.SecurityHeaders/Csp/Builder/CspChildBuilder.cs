using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspChildBuilder
    {
        private readonly CspChildSrcOptions _options = new CspChildSrcOptions();
        
        public void FromNowhere()
        {
            _options.AllowNone = true;
        }
        
        public CspChildBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspChildBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        public CspChildBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspChildBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspChildSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}