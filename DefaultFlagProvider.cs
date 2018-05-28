namespace FeatureFlag
{
    public interface IFlagProvider
    {
        bool GetFlagSetting(string flagName);
    }

    public class DefaultFlagProvider : IFlagProvider
    {
        public bool GetFlagSetting(string flagName)
        {
            //I'd get it from the config
            return false;
        }
    }
}
