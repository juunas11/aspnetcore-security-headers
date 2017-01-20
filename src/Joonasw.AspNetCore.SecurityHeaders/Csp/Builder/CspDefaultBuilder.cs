using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspDefaultBuilder
    {
        private readonly CspDefaultSrcOptions _options = new CspDefaultSrcOptions();

        internal CspDefaultSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}
