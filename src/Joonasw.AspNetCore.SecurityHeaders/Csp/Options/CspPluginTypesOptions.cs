using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspPluginTypesOptions
    {
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