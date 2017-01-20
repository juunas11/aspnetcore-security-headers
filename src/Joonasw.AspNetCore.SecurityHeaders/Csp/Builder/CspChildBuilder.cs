using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspChildBuilder
    {
        private readonly CspChildSrcOptions _options = new CspChildSrcOptions();

        internal CspChildSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}