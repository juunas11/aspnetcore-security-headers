using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    /// <summary>
    /// This directive declares an allow-list of trusted type policy names created with
    /// <c>TrustedTypes.createPolicy</c> from Trusted Types API
    /// </summary>
    public class CspTrustedTypesOptions
    {
        /// <summary>
        /// Collection of sources from where these resources can be loaded.
        /// </summary>
        /// <remark>
        /// A valid policy name consists only of alphanumeric characters, or one of "-#=_/@.%".
        /// </remark>
        public ICollection<string> TrustedPolicies { get; set; }
        
        /// <summary>
        /// If <c>true</c> allows for creating policies with a name that was already used.
        /// </summary>
        public bool AllowDuplicates { get; set; }
        
        /// <summary>
        /// Disallows creating any Trusted Type policy (same as not specifying any <c>policyName</c>).
        /// </summary>
        public bool AllowNone { get; set; }
        
        /// <summary>
        /// A star (*) as a policy name instructs the user agent to allow any unique policy name
        /// (<c>'allow-duplicates'</c> may relax that further).
        /// </summary>
        public bool AllowAny { get; set; }
        
        /// <summary>
        /// Instructs user agents to control the data passed to DOM XSS sink functions, like Element.innerHTML setter.
        /// Those functions only accept non-spoofable, typed values created by Trusted Type policies, and reject strings.
        /// </summary>
        public bool RequireTrustedTypesForScript { get; set; }

        public CspTrustedTypesOptions()
        {
            TrustedPolicies = new List<string>();
        }
        
        private ICollection<string> GetParts()
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

                foreach (string allowedSource in TrustedPolicies)
                {
                    parts.Add(allowedSource);
                }
                
                if (AllowDuplicates)
                {
                    parts.Add("'allow-duplicates'");
                }
            }
            return parts;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            ICollection<string> parts = GetParts();

            if (parts.Count == 0)
            {
                return string.Empty;
            }

            var result = "trusted-types " + string.Join(" ", parts);
            
            if (RequireTrustedTypesForScript)
            {
                result += "; require-trusted-types-for 'script'";
            }

            return result;
        }
    }
}
