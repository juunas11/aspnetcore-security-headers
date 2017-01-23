using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy rules
    /// related to sandbox exceptions.
    /// </summary>
    public class CspSandboxBuilder
    {
        private readonly CspSandboxOptions _options = new CspSandboxOptions();

        /// <summary>
        /// Allow submission of forms.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowForms()
        {
            _options.AllowForms = true;
            return this;
        }

        /// <summary>
        /// Allow execution of JavaScript.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowScripts()
        {
            _options.AllowScripts = true;
            return this;
        }

        /// <summary>
        /// Allow modal windows.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowModals()
        {
            _options.AllowModals = true;
            return this;
        }

        /// <summary>
        /// Allow to disable the ability
        /// to lock the screen orientation.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowOrientationLock()
        {
            _options.AllowOrientationLock = true;
            return this;
        }

        /// <summary>
        /// Allow to use the Pointer Lock API.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowPointerLock()
        {
            _options.AllowPointerLock = true;
            return this;
        }

        /// <summary>
        /// Allow pop-ups, e.g. ones created with
        /// window.open().
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowPopups()
        {
            _options.AllowPopups = true;
            return this;
        }

        /// <summary>
        /// Allow pop-ups opened to run outside the sandbox.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowPopupsToEscapeSandbox()
        {
            _options.AllowPopupsToEscapeSandbox = true;
            return this;
        }

        /// <summary>
        /// Allow embedders to have control over
        /// whether an iframe can start a presentation session.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowPresentation()
        {
            _options.AllowPresentation = true;
            return this;
        }

        /// <summary>
        /// Allow the content to be treated as being from its
        /// normal origin. If this exception is not enabled, the
        /// embedded content is treated as being from a unique origin.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowSameOrigin()
        {
            _options.AllowSameOrigin = true;
            return this;
        }

        /// <summary>
        /// Allow the embedded browsing context to navigate
        /// (load) content to the top-level browsing context. 
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspSandboxBuilder AllowTopNavigation()
        {
            _options.AllowTopNavigation = true;
            return this;
        }

        public CspSandboxOptions BuildOptions()
        {
            return _options;
        }
    }
}