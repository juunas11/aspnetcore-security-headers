using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspStylesBuilder
    {
        private readonly CspStyleSrcOptions _options = new CspStyleSrcOptions();

        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        public CspStylesBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspStylesBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        public CspStylesBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspStylesBuilder AllowUnsafeInline()
        {
            _options.AllowUnsafeInline = true;
            return this;
        }

        public CspStylesBuilder AddNonce()
        {
            _options.AddNonce = true;
            return this;
        }

        public CspStylesBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspStyleSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}