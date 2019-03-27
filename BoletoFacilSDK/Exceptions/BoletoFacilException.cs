using System;

namespace BoletoFacilSDK.Exceptions
{
    public class BoletoFacilException : Exception
    {
        public BoletoFacilException()
        {
        }

        public BoletoFacilException(string message)
            : base(message)
        {
        }

        public BoletoFacilException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}