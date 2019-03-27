using System;

namespace BoletoFacilSDK.Exceptions
{
    public class BoletoFacilTokenException : BoletoFacilException 
    {
        public BoletoFacilTokenException(string message)
            : base(message)
        {
        }

        public BoletoFacilTokenException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}