using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspScriptsBuilder
    {
        private readonly CspScriptSrcOptions _options = new CspScriptSrcOptions();

        public void FromNowhere()
        {
            _options.AllowNone = true;
        }

        public CspScriptsBuilder FromSelf()
        {
            _options.AllowSelf = true;
            return this;
        }

        public CspScriptsBuilder From(string uri)
        {
            if(uri == null) throw new ArgumentNullException(nameof(uri));
            if(uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _options.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow inline scripts.
        /// If you have an XSS vulnerability, this will allow them to execute.
        /// Cannot be enabled together with AddNonce
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Generates a random nonce for each request and
        /// adds it to the CSP header. Allows inline scripts that
        /// have the nonce attribute set to the random value on
        /// the script element.
        /// Note that you must call AddCsp() on the service
        /// collection for this to work.
        /// </summary>
        /// <returns></returns>
        public CspScriptsBuilder AddNonce()
        {
            _options.AddNonce = true;
            return this;
        }

        public CspScriptsBuilder FromAnywhere()
        {
            _options.AllowAny = true;
            return this;
        }

        public CspScriptsBuilder OnlyOverHttps()
        {
            _options.AllowOnlyHttps = true;
            return this;
        }

        public CspScriptSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}