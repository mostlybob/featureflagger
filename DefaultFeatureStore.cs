namespace FeatureFlag
{
    interface IFeatureStore
    {
        string GetFeatureSetting(string featureName);
    }
    
    class DefaultFeatureStore : IFeatureStore
    {
        public string GetFeatureSetting(string featureName)
        {
            return "true";
        }
    }
}
