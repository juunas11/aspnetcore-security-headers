using System;
using Joonasw.AspNetCore.SecurityHeaders.XFrameOptions;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class XFrameOptionsTests
    {
        [Fact]
        public void DenySetByDefault_ResultIsCorrect()
        {
            var options = new XFrameOptionsOptions();

            Assert.Equal(XFrameOptionsOptions.XFrameOptionsValues.Deny, options.HeaderValue);
        }

        [Fact]
        public void ValueSetIsMaintained_ResultIsCorrect()
        {
            const XFrameOptionsOptions.XFrameOptionsValues expected 
                = XFrameOptionsOptions.XFrameOptionsValues.AllowAll;

            var options = new XFrameOptionsOptions(expected);

            Assert.Equal(expected, options.HeaderValue);
        }

        [Fact]
        public void WhenSetAllowFromUrlIsRequired_ResultIsCorrect()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var options = new XFrameOptionsOptions(XFrameOptionsOptions.XFrameOptionsValues.AllowFrom);
            });
        }

        [Fact]
        public void WhenSetAllowFromUrlDoesNotThrow_ResultIsCorrect()
        {
            var options = Record.Exception(() => 
                new XFrameOptionsOptions(XFrameOptionsOptions.XFrameOptionsValues.AllowFrom, "https://google.com"));

            Assert.Null(options);
        }
    }
}
