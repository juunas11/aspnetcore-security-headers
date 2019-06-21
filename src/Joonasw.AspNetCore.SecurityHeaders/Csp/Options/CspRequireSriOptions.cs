using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspRequireSriOptions
    {
        /// <summary>
        /// If <c>true</c> subresource integrity attributes will be required for scripts loaded from this page
        /// </summary>
        public bool ForScripts { get; set; }

        /// <summary>
        /// If <c>true</c> subresource integrity attributes will be required for stylesheets loaded from this page
        /// </summary>
        public bool ForStyles { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            if (!ForScripts && !ForStyles)
            {
                return string.Empty;
            }

            var requiredOn = new List<string>(2);
            if (ForScripts)
            {
                requiredOn.Add("script");
            }

            if (ForStyles)
            {
                requiredOn.Add("style");
            }

            return $"require-sri-for {string.Join(" ", requiredOn)}";

        }
    }
}
