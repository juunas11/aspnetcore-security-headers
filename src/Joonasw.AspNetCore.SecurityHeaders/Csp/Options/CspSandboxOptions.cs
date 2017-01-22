using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Options
{
    public class CspSandboxOptions
    {
        /// <summary>
        /// Allow page to submit forms.
        /// </summary>
        public bool AllowForms { get; set; }
        /// <summary>
        /// Allow content as being from its normal origin.
        /// </summary>
        public bool AllowSameOrigin { get; set; }
        /// <summary>
        /// Allow content to run scripts, but not create pop-ups.
        /// </summary>
        public bool AllowScripts { get; set; }
        /// <summary>
        /// Allow popups with e.g. window.open().
        /// </summary>
        public bool AllowPopups { get; set; }
        /// <summary>
        /// Allow modal windows.
        /// </summary>
        public bool AllowModals { get; set; }
        /// <summary>
        /// Allow the page to disable the ability to lock the screen orientation.
        /// </summary>
        public bool AllowOrientationLock { get; set; }
        /// <summary>
        /// Allow the page to use the Pointer Lock API.
        /// </summary>
        public bool AllowPointerLock { get; set; }
        /// <summary>
        /// Allow embedders to have control over whether an iframe can
        /// start a presentation session.
        /// </summary>
        public bool AllowPresentation { get; set; }
        /// <summary>
        /// Allow a sandboxed document to open new windows without
        /// forcing the sandboxing flags upon them. This will allow,
        /// for example, a third-party advertisement to be safely
        /// sandboxed without forcing the same restrictions upon a landing page.
        /// </summary>
        public bool AllowPopupsToEscapeSandbox { get; set; }
        /// <summary>
        /// Allows the embedded browsing context to navigate (load)
        /// content to the top-level browsing context.
        /// </summary>
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
            return "sandbox " + string.Join(" ", parts);
        }
    }
}