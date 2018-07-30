using System;

namespace Joonasw.AspNetCore.SecurityHeaders.XXssProtection
{
    internal static class XXssProtectionExtensions
    {
        public static string BuildHeaderValue(this XXssProtectionOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            var headerValue = options.EnableProtection ? "1" : "0";
            if (options.EnableAttackBlock)
            {
                headerValue += "; mode=block";
            }

            return headerValue;
        }
    }
}
