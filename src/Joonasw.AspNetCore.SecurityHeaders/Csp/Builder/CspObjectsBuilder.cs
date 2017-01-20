using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspObjectsBuilder
    {
        private readonly CspObjectSrcOptions _options = new CspObjectSrcOptions();

        internal CspObjectSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}