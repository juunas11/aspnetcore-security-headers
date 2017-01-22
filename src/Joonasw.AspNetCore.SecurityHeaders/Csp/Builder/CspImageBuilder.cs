using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspImageBuilder
    {
        private readonly CspImgSrcOptions _options = new CspImgSrcOptions();

        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        public CspImageBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspImageBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        public CspImageBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspImageBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspImageBuilder DataScheme()
        {
            _options.AllowDataScheme = true;
            return this;
        }

        public CspImgSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}