using System;

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
}
