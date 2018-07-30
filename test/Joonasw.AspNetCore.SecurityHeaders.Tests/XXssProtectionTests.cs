using Joonasw.AspNetCore.SecurityHeaders.XXssProtection;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class XXssProtectionTests
    {
        [Fact]
        public void EnabledAndBlockedByDefault_ResultIsCorrect()
        {
            var options = new XXssProtectionOptions();

            Assert.True(options.EnableProtection);
            Assert.True(options.EnableAttackBlock);
        }

        [Fact]
        public void EnabledAndBlockedAreOffWhenSet_ResultIsCorrect()
        {
            var options = new XXssProtectionOptions(false, false);

            Assert.False(options.EnableProtection);
            Assert.False(options.EnableAttackBlock);
        }
    }
}
