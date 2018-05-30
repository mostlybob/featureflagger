namespace FeatureFlag
{
    public interface IFeatureStore
    {
        string GetFeatureSetting(string featureName);
    }
}
