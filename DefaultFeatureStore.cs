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
        private readonly IConfigurationBuilder builder;
        private readonly IConfiguration configuration;


        public JsonFeatureStore()
        {
            builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("FeatureFlags.json");

            configuration = builder.Build();
        }
        public string GetFeatureSetting(string featureName)
        {
            var setting = configuration[featureName];
            return setting;
        }
    }
}
