using System;
using Microsoft.Extensions.Configuration.Json;

namespace FeatureFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            var flagTest = new FlagAttrTest();
            Console.WriteLine(flagTest.TestMethod());
        }
    }


    public class FlagAttrTest
    {
        private readonly IFlagProvider flagProvider;

        public FlagAttrTest()
        {
            flagProvider = new DefaultFlagProvider();
        }
        public string TestMethod()
        {
            var flagName = "testFlag";
            var flagValue = flagProvider.GetFlagSetting(flagName);

            return $"The value for {flagName} is {flagValue}";
        }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class FeatureFlagAttribute : Attribute
    {
        private string featureName;

        public FeatureFlagAttribute(string featureName)
        {
            this.featureName = featureName;
            var bar = Match(featureName);
        }

        public bool FeatureIsEnabled()
        {
            // check for the setting for featureName variable
            return true;
        }
    }
}
