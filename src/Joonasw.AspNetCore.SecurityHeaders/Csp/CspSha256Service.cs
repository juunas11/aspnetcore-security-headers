using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public class CspSha256Service : ICspSha256Service
    {
        List<string> _shaScripts=new List<string>();
        List<string> _shaStyles = new List<string>();
        static SHA256 sha = SHA256.Create();
        public string AddShaStyles(string content)
        {
            var sha256 = System.Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(content)));
            _shaStyles.Add(sha256);
            return sha256;
        }
        public string AddShaScripts(string content)
        {
            var sha256 = System.Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(content)));
            _shaScripts.Add(sha256);
            return sha256;
        }

        public List<string> GetShaStyles()
        {
            return _shaStyles;
        }
        public List<string> GetShaScripts()
        {
            return _shaScripts;
        }
    }
}
