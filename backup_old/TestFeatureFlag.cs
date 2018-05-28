using System;

namespace FeatureFlag
{
    interface IFeatureFlag
    {
        bool FeatureIsEnabled(string featureName);
    }

    class TestFeatureFlag : IFeatureFlag
    {
        private readonly IFeatureStore featureStore;

        public TestFeatureFlag()
        {
            featureStore = new DefaultFeatureStore();
        }

        public bool FeatureIsEnabled(string featureName)
        {
            var featureSetting = featureStore.GetFeatureSetting(featureName);

            try
            {
                return Convert.ToBoolean(featureSetting);
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
