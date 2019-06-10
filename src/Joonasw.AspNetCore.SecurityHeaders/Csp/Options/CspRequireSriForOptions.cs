using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options {
    public class CspRequireSriForOptions {
        /// <summary>
        /// If <c>true</c> subresource integrity attributes will be required for scripts loaded from this page
        /// </summary>
        public bool Script { get; set; }

        /// <summary>
        /// If <c>true</c> subresource integrity attributes will be required for stylesheets loaded from this page
        /// </summary>
        public bool Style { get; set; }

        /// <inheritdoc />
        public override string ToString() {
            if ((Script == false) && (Style == false))
            {
                return string.Empty;
            }

            List<string> requiredOn = new List<string>(2);
            if (Script == true)
            {
                requiredOn.Add("script");
            }
            if (Style == true)
            {
                requiredOn.Add("style");
            }

            return $"require-sri-for {string.Join(" ", requiredOn)}";

        }
    }
}
