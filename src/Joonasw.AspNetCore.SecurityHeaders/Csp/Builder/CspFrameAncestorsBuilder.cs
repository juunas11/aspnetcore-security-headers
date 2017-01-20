using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspFrameAncestorsBuilder
    {
        private readonly CspFrameAncestorsOptions _options = new CspFrameAncestorsOptions();

        internal CspFrameAncestorsOptions BuildOptions()
        {
            return _options;
        }
    }
}