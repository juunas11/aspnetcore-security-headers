using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options
{
    public abstract class FeaturePolicyOptionsBase
    {
        private readonly string _directiveName;
        /// <summary>
        /// Collection of origins from where these resources can be loaded.
        /// </summary>
        public ICollection<string> AllowedOrigins { get; set; }
        /// <summary>
        /// Allow loading these resources from the same domain as the app.
        /// </summary>
        public bool AllowSelf { get; set; }
        /// <summary>
        /// Block loading of these resources.
        /// </summary>
        public bool AllowNone { get; set; }
        /// <summary>
        /// Allows any source except data:, blob:, and filesystem: schemes.
        /// </summary>
        public bool AllowAny { get; set; }

        protected FeaturePolicyOptionsBase(string directiveName)
        {
            _directiveName = directiveName;
            AllowedOrigins = new List<string>();   
        }

        protected virtual ICollection<string> GetParts()
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
                if (AllowedOrigins.Count > 0)
                {
                    parts.Add(string.Join(" ", AllowedOrigins));
                }
            }
            return parts;
        }

        public override string ToString()
        {
            var parts = GetParts();

            return parts.Count == 0 ? string.Empty : $"{_directiveName} {string.Join(" ", parts)}";
        }
    }
}
