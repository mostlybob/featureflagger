using System;

namespace FeatureFlag
{
    public interface IFlagProvider
    {
        bool GetFlagSetting(string flagName);
    }

    public class FlagProvider : IFlagProvider
    {
        public bool GetFlagSetting(string flagName)
        {
            return false;
        }
    }


    public interface IFeatureStore
    {
        string GetFeatureSetting(string featureName);
    }
}
