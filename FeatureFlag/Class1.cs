namespace FeatureFlag
{
    public interface IFeatureStore
    {
        string GetFeatureSetting(string featureName);
    }

    public class JsonFeatureStore : IFeatureStore
    {
        public string GetFeatureSetting(string featureName)
        {
            throw new System.NotImplementedException();
        }
    }
}
