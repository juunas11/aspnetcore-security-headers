using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspFontsBuilder
    {
        private readonly CspFontSrcOptions _options = new CspFontSrcOptions();

        internal CspFontSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}