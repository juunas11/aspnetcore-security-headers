using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspStylesBuilder
    {
        private readonly CspStyleSrcOptions _options = new CspStyleSrcOptions();

        public CspStylesBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspStylesBuilder From(string source)
        {
            _options.AllowedSources.Add(source);
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

        internal CspStyleSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}