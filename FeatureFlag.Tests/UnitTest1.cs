using System;
using Xunit;
using Moq;
using FeatureFlag;
using Shouldly;

namespace FeatureFlag.Tests
{
    public class ProviderTests
    {
        string testKey;
        private IFlagProvider providerTest;


        public ProviderTests()
        {
            var featureStoreMock = new Mock<IFeatureStore>();

            featureStoreMock
            .Setup(yy => yy.GetFeatureSetting(It.IsAny<string>()))
            .Returns("True");

            testKey = Guid.NewGuid().ToString();

        }

        [Fact]
        public void It_should_return_false_for_non_existent_key()
        {
            var featureStoreMock = new Mock<IFeatureStore>();

            providerTest = new FlagProvider(featureStoreMock.Object);

            providerTest.GetFlagSetting("bogus").ShouldBeFalse();
        }

        [Fact]
        public void It_should_call_the_store_with_the_key()
        {
            var featureStoreMock = new Mock<IFeatureStore>();

            featureStoreMock
            .Setup(yy => yy.GetFeatureSetting(It.IsAny<string>()))
            .Returns("True");

            providerTest = new FlagProvider(featureStoreMock.Object);

            providerTest.GetFlagSetting(testKey);

            featureStoreMock.Verify(xx => xx.GetFeatureSetting(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void It_should_call_the_store_with_the_passed_key()
        {
                       var featureStoreMock = new Mock<IFeatureStore>();

            featureStoreMock
            .Setup(yy => yy.GetFeatureSetting(testKey))
            .Returns("True");

            providerTest = new FlagProvider(featureStoreMock.Object);

            providerTest.GetFlagSetting(testKey);

            featureStoreMock.Verify(xx => xx.GetFeatureSetting(testKey), Times.Once);
        }

        [Fact]
        public void It_should_return_true_when_store_returns_a_true_string()
        {
            var featureStoreMock = new Mock<IFeatureStore>();

            featureStoreMock
            .Setup(yy => yy.GetFeatureSetting(testKey))
            .Returns("True");

            providerTest = new FlagProvider(featureStoreMock.Object);

            providerTest.GetFlagSetting(testKey).ShouldBeTrue();
        }

    }
}
