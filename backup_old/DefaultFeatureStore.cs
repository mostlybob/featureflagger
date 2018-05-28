using System;
using System.IO;
using Microsoft.Extensions.Configuration;

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

    public class JsonFeatureStore : IFeatureStore
    {
        private readonly IConfiguration configuration;

        public JsonFeatureStore()
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("FeatureFlags.json").Build();
        }
        public string GetFeatureSetting(string featureName)
        {
            return configuration[featureName];
        }
    }
}
