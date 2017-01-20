using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspPluginTypesBuilder
    {
        private readonly CspPluginTypesOptions _options = new CspPluginTypesOptions();

        public CspPluginTypesBuilder WithMimeType(string mimeType)
        {
            _options.AllowedMediaTypes.Add(mimeType);
            return this;
        }

        internal CspPluginTypesOptions BuildOptions()
        {
            return _options;
        }
    }
}