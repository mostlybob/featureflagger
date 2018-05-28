using System;

namespace FeatureFlag
{
    public interface IFlagProvider
    {
        bool GetFlagSetting(string flagName);
    }

    public class DefaultFlagProvider : IFlagProvider
    {
        private readonly IFeatureStore featureStore;

        public DefaultFlagProvider()
        {
            featureStore = new DefaultFeatureStore();
        }

        public bool GetFlagSetting(string flagName)
        {
            var featureSetting=featureStore.GetFeatureSetting(flagName);
            return Convert.ToBoolean(featureSetting);
        }
    }

    public class JsonFlagProvider : IFlagProvider
    {
        private readonly IFeatureStore featureStore;

        public JsonFlagProvider()
        {
            featureStore = new JsonFeatureStore();
        }

        public bool GetFlagSetting(string flagName)
        {
            return featureStore.GetFeatureSetting(flagName);
        }
    }
}
