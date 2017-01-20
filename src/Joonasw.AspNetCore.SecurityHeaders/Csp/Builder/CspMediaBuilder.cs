using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspMediaBuilder
    {
        private readonly CspMediaSrcOptions _options = new CspMediaSrcOptions();

        internal CspMediaSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}