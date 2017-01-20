using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspSandboxOptions
    {
        public bool AllowForms { get; set; }
        public bool AllowSameOrigin { get; set; }
        public bool AllowScripts { get; set; }
        public bool AllowPopups { get; set; }
        public bool AllowModals { get; set; }
        public bool AllowOrientationLock { get; set; }
        public bool AllowPointerLock { get; set; }
        public bool AllowPresentation { get; set; }
        public bool AllowPopupsToEscapeSandbox { get; set; }
        public bool AllowTopNavigation { get; set; }

        public override string ToString()
        {
            ICollection<string> parts = new List<string>();

            if (AllowForms)
            {
                parts.Add("allow-forms");
            }
            if (AllowSameOrigin)
            {
                parts.Add("allow-same-origin");
            }
            if (AllowScripts)
            {
                parts.Add("allow-scripts");
            }
            if (AllowPopups)
            {
                parts.Add("allow-popups");
            }
            if (AllowModals)
            {
                parts.Add("allow-modals");
            }
            if (AllowOrientationLock)
            {
                parts.Add("allow-orientation-lock");
            }
            if (AllowPointerLock)
            {
                parts.Add("allow-pointer-lock");
            }
            if (AllowPresentation)
            {
                parts.Add("allow-presentation");
            }
            if (AllowPopupsToEscapeSandbox)
            {
                parts.Add("allow-popups-to-escape-sandbox");
            }
            if (AllowTopNavigation)
            {
                parts.Add("allow-top-navigation");
            }

            if (parts.Count == 0)
            {
                return string.Empty;
            }
            return "sanbox " + string.Join(" ", parts);
        }
    }
}