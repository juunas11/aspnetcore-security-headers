using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspMediaBuilder
    {
        private readonly CspMediaSrcOptions _options = new CspMediaSrcOptions();

        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        public CspMediaBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspMediaBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        public CspMediaBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspMediaBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspMediaSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}