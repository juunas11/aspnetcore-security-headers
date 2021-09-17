using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public interface ICspSha256Service
    {
        string AddShaScripts(string content);
        string AddShaStyles(string content);
        List<string> GetShaScripts();
        List<string> GetShaStyles();

    }
}
