using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Exceptions
{
    public class BoletoFacilRequestException : BoletoFacilException
    {
        public int HTTPStatusCode { get; protected set; }
        public ErrorResponse Error { get; private set; }

        public BoletoFacilRequestException(string message)
            : base(message)
        {
        }

        public BoletoFacilRequestException(int httpStatusCode, string responseBody)
            : base($"Erro na requisição (HTTP Code {httpStatusCode}): {responseBody}")
        {
            HTTPStatusCode = httpStatusCode;
        }

        public BoletoFacilRequestException(int httpStatusCode, ErrorResponse error)
            : base($"Erro na requisição (HTTP Code {httpStatusCode}): {error.ErrorMessage}")
        {
            HTTPStatusCode = httpStatusCode;
            Error = error;
        }
    }
}