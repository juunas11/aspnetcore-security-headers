using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspDefaultBuilder
    {
        private readonly CspDefaultSrcOptions _options = new CspDefaultSrcOptions();

        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        public CspDefaultBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspDefaultBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        public CspDefaultBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspDefaultBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspDefaultSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}
