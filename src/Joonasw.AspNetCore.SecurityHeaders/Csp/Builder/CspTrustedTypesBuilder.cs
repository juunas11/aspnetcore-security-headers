using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy
    /// rules related to Trusted Types.
    /// </summary>
    public class CspTrustedTypesBuilder
    {
        private readonly CspTrustedTypesOptions _options = new CspTrustedTypesOptions();

        /// <summary>
        /// Disallows creating any Trusted Type policy (same as not specifying any <c>policyName</c>).
        /// </summary>
        public void DisallowAll()
        {
            _options.AllowNone = true;
        }
        
        /// <summary>
        /// Allow any unique policy name ('allow-duplicates' may relax that further)
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspTrustedTypesBuilder WithAnyUniquePolicy()
        {
            _options.AllowAny = true;
            return this;
        }
        
        /// <summary>
        /// Allow CSS from the given
        /// <paramref name="policyName"/>.
        /// </summary>
        /// <param name="policyName">A valid policy name consists only of alphanumeric characters, or one of "-#=_/@.%". </param>
        /// <returns>The builder for call chaining</returns>
        public CspTrustedTypesBuilder WithPolicyName(string policyName)
        {
            if (policyName == null) throw new ArgumentNullException(nameof(policyName));
            if (policyName.Length == 0) throw new ArgumentException("Policy Name can't be empty", nameof(policyName));

            _options.TrustedPolicies.Add(policyName);
            return this;
        }
        
        public CspTrustedTypesBuilder AllowDuplicates()
        {
            _options.AllowDuplicates = true;
            return this;
        }
        
        public CspTrustedTypesBuilder RequireTrustedTypesForScript()
        {
            _options.RequireTrustedTypesForScript = true;
            return this;
        }
        
        public CspTrustedTypesOptions BuildOptions()
        {
            return _options;
        }
    }
}
