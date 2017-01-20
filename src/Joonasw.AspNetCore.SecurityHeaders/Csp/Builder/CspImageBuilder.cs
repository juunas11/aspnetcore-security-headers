using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspImageBuilder
    {
        private readonly CspImgSrcOptions _options = new CspImgSrcOptions();

        internal CspImgSrcOptions BuildOptions()
        {
            return _options;
        }
    }
}