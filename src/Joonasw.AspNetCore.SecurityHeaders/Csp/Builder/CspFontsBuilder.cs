using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspFontsBuilder
    {
        private readonly CspFontSrcOptions _options = new CspFontSrcOptions();

        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        public CspFontsBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspFontsBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        public CspFontsBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspFontsBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspFontSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}