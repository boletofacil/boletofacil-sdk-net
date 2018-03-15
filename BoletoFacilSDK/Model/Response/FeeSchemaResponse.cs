using System.Runtime.Serialization;
using System.Xml.Serialization;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Model.Response
{
    [DataContract, XmlRoot("result")]
    public class FeeSchemaResponse : BaseResponse
    {
        [DataMember, XmlElement("data")]
        public FeeSchema Data { get; set; }
    }
}
