using System.IO;
using System;
using Microsoft.Extensions.Configuration;

namespace FeatureFlag
{
    public interface IFeatureStore
    {
        string GetFeatureSetting(string featureName);
    }

    public class JsonFeatureStore : IFeatureStore
    {
        private readonly IConfiguration configuration;

        // default constructor will just get the file from the application folders
        // other (testable) options: 
        //      - inject the JSON string 
        //      - inject a filepath object pointing to the file
        public JsonFeatureStore()
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("FeatureFlags.json")
            .Build();
        }
        
        public string GetFeatureSetting(string featureName)
        {
            return configuration[featureName];
        }
    }
}
