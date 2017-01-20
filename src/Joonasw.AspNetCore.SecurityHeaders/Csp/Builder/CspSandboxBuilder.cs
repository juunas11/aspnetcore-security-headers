using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    public class CspSandboxBuilder
    {
        private readonly CspSandboxOptions _options = new CspSandboxOptions();

        public CspSandboxBuilder AllowForms()
        {
            _options.AllowForms = true;
            return this;
        }
        public CspSandboxBuilder AllowScripts()
        {
            _options.AllowScripts = true;
            return this;
        }
        public CspSandboxBuilder AllowModals()
        {
            _options.AllowModals = true;
            return this;
        }
        public CspSandboxBuilder AllowOrientationLock()
        {
            _options.AllowOrientationLock = true;
            return this;
        }
        public CspSandboxBuilder AllowPointerLock()
        {
            _options.AllowPointerLock = true;
            return this;
        }
        public CspSandboxBuilder AllowPopups()
        {
            _options.AllowPopups = true;
            return this;
        }
        public CspSandboxBuilder AllowPopupsToEscapeSandbox()
        {
            _options.AllowPopupsToEscapeSandbox = true;
            return this;
        }
        public CspSandboxBuilder AllowPresentation()
        {
            _options.AllowPresentation = true;
            return this;
        }
        public CspSandboxBuilder AllowSameOrigin()
        {
            _options.AllowSameOrigin = true;
            return this;
        }
        public CspSandboxBuilder AllowTopNavigation()
        {
            _options.AllowTopNavigation = true;
            return this;
        }

        internal CspSandboxOptions BuildOptions()
        {
            return _options;
        }
    }
}