using System;

namespace FeatureFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            var flagTest = new FlagAttrTest();
            Console.WriteLine($"Running Default: {flagTest.TestMethod()}");

            flagTest = new FlagAttrTest(new JsonFlagProvider());
            Console.WriteLine($"Running Json: {flagTest.TestMethod()}");
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
