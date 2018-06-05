using System;

namespace FeatureFlag
{
    public interface IFlagProvider
    {
        bool GetFlagSetting(string flagName);
    }

    public class FlagProvider : IFlagProvider
    {
        private readonly Func<IFeatureStore> featureStore;

        public FlagProvider(Func<IFeatureStore> featureStore)
        {
            this.featureStore = featureStore;
        }

        public bool GetFlagSetting(string flagName)
        {
            var setting = featureStore().GetFeatureSetting(flagName);

            return Convert.ToBoolean(setting);
        }
    }
}
