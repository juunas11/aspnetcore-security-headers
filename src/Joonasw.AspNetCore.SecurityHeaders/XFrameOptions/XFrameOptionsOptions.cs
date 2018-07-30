using System;
using System.ComponentModel;

namespace Joonasw.AspNetCore.SecurityHeaders.XFrameOptions
{
    public class XFrameOptionsOptions
    {
        public XFrameOptionsOptions()
        {
            
        }

        /// <summary>
        /// Defines the parameters for the X-Frame-Options header sent in response to clients
        /// </summary>
        /// <param name="value">The Value to be applied to the header X-Frame-Options header</param>
        /// <param name="allowFromUrl">If ALLOW-FROM is selected, then this value is
        /// required and must have sited that are permitted to frame your site.
        /// Note: Chrome does not support the ALLOW-FROM option
        /// Null by default</param>
        public XFrameOptionsOptions(XFrameOptionsValues value, string allowFromUrl = null)
        {
            HeaderValue = value;

            if (value == XFrameOptionsValues.AllowFrom && string.IsNullOrWhiteSpace(allowFromUrl))
                throw new ArgumentException("ALLOW-FROM URL string cannot be empty when ALLOW-FROM option is selected.");
            AllowFromUrl = allowFromUrl;
        }

        /// <summary>
        /// Gets the predefined value to be applied to the header X-Frame-Options header.
        /// DENY is set by default.
        /// Note: Chrome does not support the ALLOW-FROM option
        /// </summary>
        public XFrameOptionsValues HeaderValue { get; set; } = XFrameOptionsValues.Deny;

        /// <summary>
        /// Gets the url allowed from a single domain.
        /// Note: Chrome does not support the ALLOW-FROM option
        /// </summary>
        public string AllowFromUrl { get; set; }

        public enum XFrameOptionsValues
        {
            [DefaultValue("DENY")]
            Deny = 0,
            [DefaultValue("SAMEORIGIN")]
            SameOrigin = 1,
            [DefaultValue("ALLOW-FROM")]
            AllowFrom = 2,
            [DefaultValue("ALLOWALL")]
            AllowAll = 3
        }
    }
}
