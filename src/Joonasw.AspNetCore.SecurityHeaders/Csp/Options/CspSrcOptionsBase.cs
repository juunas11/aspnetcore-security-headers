using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public abstract class CspSrcOptionsBase
    {
        private readonly string _directiveName;

        /// <summary>
        /// Collection of sources from where these resources can be loaded.
        /// </summary>
        public ICollection<string> AllowedSources { get; set; }
        /// <summary>
        /// Allow loading these resources from the same domain as the app.
        /// </summary>
        public bool AllowSelf { get; set; }
        /// <summary>
        /// Block loading of these resources.
        /// </summary>
        public bool AllowNone { get; set; }
        /// <summary>
        /// Allow loading only through secure channels.
        /// </summary>
        public bool AllowOnlyHttps { get; set; }
        /// <summary>
        /// Allows loading via data scheme, e.g. Base64-encoded images.
        /// </summary>
        public bool AllowDataScheme { get; set; }
        /// <summary>
        /// Allows any source except data:, blob:, and filesystem: schemes.
        /// </summary>
        public bool AllowAny { get; set; }

        protected CspSrcOptionsBase(string directiveName)
        {
            _directiveName = directiveName + " ";
            AllowedSources = new List<string>();
        }

        protected virtual ICollection<string> GetParts(ICspNonceService nonceService)
        {
            ICollection<string> parts = new List<string>();

            if (AllowNone)
            {
                parts.Add("'none'");
            }
            else
            {
                if (AllowAny)
                {
                    parts.Add("*");
                }
                if (AllowSelf)
                {
                    parts.Add("'self'");
                }
                if (AllowOnlyHttps)
                {
                    parts.Add("https:");
                }
                if (AllowDataScheme)
                {
                    parts.Add("data:");
                }

                foreach (string allowedSource in AllowedSources)
                {
                    parts.Add(allowedSource);
                }
            }
            return parts;
        }

        public string ToString(ICspNonceService nonceService)
        {
            ICollection<string> parts = GetParts(nonceService);

            if (parts.Count == 0)
            {
                return string.Empty;
            }
            return _directiveName + string.Join(" ", parts);
        }
    }
}