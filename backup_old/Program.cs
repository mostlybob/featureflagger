using System;
using System.Collections;
using System.Collections.Generic;

namespace FeatureFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            var flagTest = new FlagAttrTest();
            Console.WriteLine($"Running Default: {flagTest.TestMethod()}");

            var jsonProvider = new JsonFlagProvider();
            flagTest = new FlagAttrTest(jsonProvider);
            Console.WriteLine($"Running Json: {flagTest.TestMethod()}");

            var flags = new List<string> { "testFlag", "Flag1", "Flag2", "Flag3", "missingFlag" };

            foreach (var flag in flags)
            {
                Console.WriteLine($"Running Json provider for {flag}: {jsonProvider.GetFlagSetting(flag)}");
            }
        }
    }


    public class FlagAttrTest
    {
        private readonly IFlagProvider flagProvider;

        public FlagAttrTest()
        {
            flagProvider = new DefaultFlagProvider();
        }

        public FlagAttrTest(IFlagProvider flagProvider)
        {
            this.flagProvider = flagProvider;
        }

        public string TestMethod()
        {
            var flagName = "testFlag";
            var flagValue = flagProvider.GetFlagSetting(flagName);

            return $"The value for {flagName} is {flagValue}";
        }
    }
}
