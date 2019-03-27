namespace BoletoFacilSDK.Enums
{
    public enum BoletoFacilEnvironment
    {
        Production,
        Sandbox,
#if DEBUG
        UnitTests
#endif
    }
}