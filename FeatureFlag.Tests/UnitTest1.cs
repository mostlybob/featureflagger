using System;
using Xunit;
using Moq;
using FeatureFlag;
using Shouldly;

namespace FeatureFlag.Tests
{
    public class ProviderTests
    {
        private IFlagProvider providerTest;


        public ProviderTests()
        {
            var featureStoreMock = new Mock<IFeatureStore>();

            featureStoreMock
            .Setup(yy => yy.GetFeatureSetting(It.IsAny<string>()))
            .Returns("True");

            providerTest = new Mock<FlagProvider>().Object;

        }

        [Fact]
        public void Nonexistent_key_should_be_false()
        {
            providerTest.GetFlagSetting("bogus").ShouldBeFalse();
        }

        [Fact]
        public void It_should_call_the_store_with_the_key()
        {
            var key = System.Guid.NewGuid().ToString();
            var featureStoreMock = new Mock<IFeatureStore>();

            featureStoreMock
            .Setup(yy => yy.GetFeatureSetting(It.IsAny<string>()))
            .Returns("True");

            providerTest = new FlagProvider(featureStoreMock.Object);

            providerTest.GetFlagSetting(key);

            featureStoreMock.Verify(xx=>xx.GetFeatureSetting(It.IsAny<string>()),Times.Once);
        }

    }
}
