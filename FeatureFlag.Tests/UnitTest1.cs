using System;
using Xunit;
using Moq;
using FeatureFlag;
using Shouldly;

namespace FeatureFlag.Tests
{
    public class ProviderTests
    {
        private string testKey;
        private IFlagProvider providerTest;
        private Mock<IFeatureStore> mockFeatureStore;

        public ProviderTests()
        {
            testKey = Guid.NewGuid().ToString();
        }

        private void SetupMock(string key, string returnValue)
        {
            mockFeatureStore = new Mock<IFeatureStore>();

            mockFeatureStore
            .Setup(yy => yy.GetFeatureSetting(key))
            .Returns(returnValue);
        }

        [Fact]
        public void It_should_return_false_for_non_existent_key()
        {
            // var featureStoreMock = new Mock<IFeatureStore>();
            SetupMock("bogus", null);

            providerTest = new FlagProvider(mockFeatureStore.Object);

            providerTest.GetFlagSetting("bogus").ShouldBeFalse();
        }

        [Fact]
        public void It_should_call_the_store_with_the_key()
        {
            SetupMock(It.IsAny<string>(), "True");

            providerTest = new FlagProvider(mockFeatureStore.Object);

            providerTest.GetFlagSetting(testKey);

            mockFeatureStore.Verify(xx => xx.GetFeatureSetting(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void It_should_call_the_store_with_the_passed_key()
        {
            SetupMock(It.IsAny<string>(), "True");

            providerTest = new FlagProvider(mockFeatureStore.Object);

            providerTest.GetFlagSetting(testKey);

            mockFeatureStore.Verify(xx => xx.GetFeatureSetting(testKey), Times.Once);
        }

        [Fact]
        public void It_should_return_true_when_store_returns_a_true_string()
        {
            SetupMock(testKey, "True");

            providerTest = new FlagProvider(mockFeatureStore.Object);

            providerTest.GetFlagSetting(testKey).ShouldBeTrue();
        }

    }
}
