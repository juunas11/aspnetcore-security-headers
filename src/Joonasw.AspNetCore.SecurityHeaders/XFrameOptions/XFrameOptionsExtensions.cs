using System;

namespace Joonasw.AspNetCore.SecurityHeaders.XFrameOptions
{
    internal static class XFrameOptionsExtensions
    {
        public static string BuildHeaderValue(this XFrameOptionsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            var headerValue = options.HeaderValue.DefaultValue();
            if (options.HeaderValue == XFrameOptionsOptions.XFrameOptionsValues.AllowFrom)
            {
                headerValue += " " + options.AllowFromUrl;
            }

            return headerValue;
        }
    }
}
