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



        }

        [Fact]
        public void Nonexistent_key_should_be_false()
        {
            providerTest = new Mock<FlagProvider>().Object;

            providerTest.GetFlagSetting("bogus").ShouldBeFalse();
        }
    }
}
