using System;
using System.Security.Cryptography;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public class CspNonceService : ICspNonceService
    {
        private readonly string _nonce;
        private static char base64PadCharacter = '=';
        private static string doubleBase64PadCharacter = "==";
        private static char base64Character62 = '+';
        private static char base64Character63 = '/';
        private static char base64UrlCharacter62 = '-';
        private static char _base64UrlCharacter63 = '_';

        public CspNonceService(int nonceByteAmount = 32)
        {
            byte[] nonceBytes = new byte[nonceByteAmount];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(nonceBytes);
            }

          var s = Convert.ToBase64String(nonceBytes);
          // a base64String can have elements that aren't URL friendly. In testing chrome appeared to ignore nonces that weren't URL friendly (or the tag helper did).
          // the replacement code comes from Microsoft.IdentityModel.Tokens.Base64UrlEncoder
          s = s.Split(base64PadCharacter)[0]; // Remove any trailing padding
          s = s.Replace(base64Character62, base64UrlCharacter62);  // 62nd char of encoding
          s = s.Replace(base64Character63, _base64UrlCharacter63);  // 63rd char of encoding

          _nonce = s;
            
        }

        public string GetNonce()
        {
            return _nonce;
        }
    }
}
