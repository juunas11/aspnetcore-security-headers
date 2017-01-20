using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspFormActionBuilder
    {
        private readonly CspFormActionOptions _options = new CspFormActionOptions();

        internal CspFormActionOptions BuildOptions()
        {
            return _options;
        }
    }
}