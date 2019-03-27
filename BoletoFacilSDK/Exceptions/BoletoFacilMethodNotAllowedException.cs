namespace BoletoFacilSDK.Exceptions
{
    public class BoletoFacilMethodNotAllowedException : BoletoFacilRequestException
    {
        public BoletoFacilMethodNotAllowedException(string message)
            : base(message)
        {
            HTTPStatusCode = 405;
        }
    }
}
