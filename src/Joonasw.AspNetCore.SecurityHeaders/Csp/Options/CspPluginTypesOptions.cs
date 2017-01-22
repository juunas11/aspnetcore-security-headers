using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspPluginTypesOptions
    {
        /// <summary>
        /// Collection of MIME types allowed for loading resources
        /// in &lt;object&gt; and &lt;embed&gt; tags.
        /// </summary>
        public ICollection<string> AllowedMediaTypes { get; }

        public CspPluginTypesOptions()
        {
            AllowedMediaTypes = new List<string>();
        }

        public override string ToString()
        {
            if (AllowedMediaTypes.Count == 0)
            {
                return string.Empty;
            }
            return "plugin-types " + string.Join(" ", AllowedMediaTypes);
        }
    }
}