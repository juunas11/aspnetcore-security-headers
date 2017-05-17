using System;

namespace Joonasw.AspNetCore.SecurityHeaders.Hsts
{
    internal static class HstsOptionsExtensions
    {
        public static string BuildHeaderValue(this HstsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            if (options.DurationSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(options.DurationSeconds), "HSTS duration must be positive");
            }

            string headerValue = "max-age=" + options.DurationSeconds;
            if (options.IncludeSubDomains)
            {
                headerValue += "; includeSubDomains";
            }
            if (options.Preload)
            {
                headerValue += "; preload";
            }
            return headerValue;
        }
    }
}
