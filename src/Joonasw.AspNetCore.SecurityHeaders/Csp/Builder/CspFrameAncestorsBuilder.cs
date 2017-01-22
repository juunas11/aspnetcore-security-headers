using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspFrameAncestorsBuilder
    {
        private readonly CspFrameAncestorsOptions _options = new CspFrameAncestorsOptions();

        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        public CspFrameAncestorsBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspFrameAncestorsBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        public CspFrameAncestorsBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspFrameAncestorsBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspFrameAncestorsOptions BuildOptions()
        {
            return _options;
        }
    }
}