using System;
using System.Security.Cryptography;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp
{
    public class CspNonceService : ICspNonceService
    {
        private readonly string _nonce;

        public CspNonceService(int nonceByteAmount = 32)
        {
            byte[] nonceBytes = new byte[nonceByteAmount];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(nonceBytes);
            }

            _nonce = Convert.ToBase64String(nonceBytes);
        }

        public string GetNonce()
        {
            return _nonce;
        }
    }
}
