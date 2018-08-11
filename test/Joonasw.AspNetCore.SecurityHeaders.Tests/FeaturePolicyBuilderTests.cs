using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder;
using Xunit;

namespace Joonasw.AspNetCore.SecurityHeaders.Tests
{
    public class FeaturePolicyBuilderTests
    {
        [Fact]
        public void PaymentFromNowhere_SetsValue()
        {
            var builder = new FeaturePolicyBuilder();

            builder.AllowPayment.FromNowhere();
            var options = builder.BuildFeaturePolicyOptions();
            string headerValue = options.ToString();

            Assert.Equal("payment 'none'", headerValue);
        }

        [Fact]
        public void PaymentFromSelfAndGoogle_SetsValue()
        {
            var builder = new FeaturePolicyBuilder();

            builder.AllowPayment.FromSelf().From("https://www.google.com");
            var options = builder.BuildFeaturePolicyOptions();
            string headerValue = options.ToString();

            Assert.Equal("payment 'self' https://www.google.com", headerValue);
        }

        [Fact]
        public void PaymentFromNowhereAndFullScreenFromSelf_SetsValue()
        {
            var builder = new FeaturePolicyBuilder();

            builder.AllowPayment.FromNowhere();
            builder.AllowFullscreen.FromSelf();
            var options = builder.BuildFeaturePolicyOptions();
            string headerValue = options.ToString();

            Assert.Equal("fullscreen 'self'; payment 'none'", headerValue);
        }

        [Fact]
        public void OtherNewFeatureFromSelf_SetsValue()
        {
            var builder = new FeaturePolicyBuilder();

            builder.AllowOtherFeature("new-feature").FromSelf();
            var options = builder.BuildFeaturePolicyOptions();
            string headerValue = options.ToString();

            Assert.Equal("new-feature 'self'", headerValue);
        }
    }
}
