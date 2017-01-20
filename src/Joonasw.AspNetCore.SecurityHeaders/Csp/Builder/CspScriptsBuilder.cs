using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspScriptsBuilder
    {
        private readonly CspScriptSrcOptions _options = new CspScriptSrcOptions();

        public CspScriptsBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspScriptsBuilder From(string source)
        {
            _options.AllowedSources.Add(source);
            return this;
        }

        public CspScriptsBuilder AllowUnsafeInline()
        {
            _options.AllowUnsafeInline = true;
            return this;
        }

        public CspScriptsBuilder AllowUnsafeEval()
        {
            _options.AllowUnsafeEval = true;
            return this;
        }

        public CspScriptsBuilder AddNonce()
        {
            _options.AddNonce = true;
            return this;
        }

        public CspScriptSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}