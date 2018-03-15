using System.Runtime.Serialization;
using System.Xml.Serialization;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Model.Response
{
    [DataContract, XmlRoot("result")]
    public class PayeeResponse : BaseResponse
    {
        [DataMember, XmlElement("data")]
        public Payee Data { get; set; }
    }
}
