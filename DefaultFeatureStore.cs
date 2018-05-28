using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FeatureFlag
{
    interface IFeatureStore
    {
        bool GetFeatureSetting(string featureName);
    }

    class DefaultFeatureStore : IFeatureStore
    {
        public bool GetFeatureSetting(string featureName)
        {
            return true;
        }
    }

    public class JsonFeatureStore : IFeatureStore
    {
        private readonly IConfigurationBuilder builder;
        private readonly IConfiguration configuration;
        

        public JsonFeatureStore()
        {
            builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("FeatureFlags.json");

            configuration = builder.Build();
        }
        public bool GetFeatureSetting(string featureName)
        {

            return true;
        }
    }
}
