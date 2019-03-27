namespace BoletoFacilSDK.UsageExample
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
            BoletoFacilClient client = new BoletoFacilClient();
            client.MainMenu(args.Length > 0 ? args[0] : string.Empty);
        }
    }
}
