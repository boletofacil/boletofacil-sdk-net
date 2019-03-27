using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Response
{
    [DataContract, XmlRoot("result")]
    public class ErrorResponse : BaseResponse
    {
        [DataMember, XmlElement("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}