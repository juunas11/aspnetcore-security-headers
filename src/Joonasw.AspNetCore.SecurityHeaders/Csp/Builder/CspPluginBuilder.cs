using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspPluginBuilder
    {
        private readonly CspPluginTypesOptions _pluginOptions = new CspPluginTypesOptions();
        private readonly CspObjectSrcOptions _objectOptions = new CspObjectSrcOptions();

        public void FromNowhere()
        {
            _objectOptions.AllowNone = true;
        }

        public CspPluginBuilder FromSelf()
        {
            _objectOptions.AllowSelf = true;
            return this;
        }

        public CspPluginBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _objectOptions.AllowedSources.Add(uri);
            return this;
        }

        public CspPluginBuilder FromAnywhere()
        {
            _objectOptions.AllowAny = true;
            return this;
        }

        public CspPluginBuilder WithMimeType(string mimeType)
        {
            _pluginOptions.AllowedMediaTypes.Add(mimeType);
            return this;
        }

        public CspPluginBuilder OnlyOverHttps()
        {
            _objectOptions.AllowOnlyHttps = true;
            return this;
        }

        public Tuple<CspObjectSrcOptions, CspPluginTypesOptions> BuildOptions()
        {
            return Tuple.Create(_objectOptions, _pluginOptions);
        }
    }
}