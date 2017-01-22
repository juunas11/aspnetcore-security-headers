using Joonasw.AspNetCore.SecurityHeaders.Csp.Builder;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class CspSandboxBuilderTests
    {
        [Fact]
        public void AllowForms_SetsAllowFormsToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowForms();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowForms);
        }

        [Fact]
        public void AllowModals_SetsAllowModalsToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowModals();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowModals);
        }

        [Fact]
        public void AllowOrientationLock_SetsAllowOrientationLockToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowOrientationLock();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowOrientationLock);
        }

        [Fact]
        public void AllowPointerLock_SetsAllowPointerLockToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowPointerLock();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowPointerLock);
        }

        [Fact]
        public void AllowPopups_SetsAllowPopupsToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowPopups();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowPopups);
        }

        [Fact]
        public void AllowPopupsToEscapeSandbox_SetsAllowPopupsToEscapeSandboxToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowPopupsToEscapeSandbox();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowPopupsToEscapeSandbox);
        }

        [Fact]
        public void AllowPresentation_SetsAllowPresentationToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowPresentation();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowPresentation);
        }

        [Fact]
        public void AllowSameOrigin_SetsAllowSameOriginToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowSameOrigin();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowSameOrigin);
        }

        [Fact]
        public void AllowScripts_SetsAllowScriptsToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowScripts();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowScripts);
        }

        [Fact]
        public void AllowTopNavigation_SetsAllowTopNavigationToTrue()
        {
            var builder = new CspSandboxBuilder();

            builder.AllowTopNavigation();
            CspSandboxOptions options = builder.BuildOptions();

            Assert.True(options.AllowTopNavigation);
        }
    }
}
