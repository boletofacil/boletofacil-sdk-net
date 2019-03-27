using System.Runtime.Serialization;
using System.Xml.Serialization;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Model.Response
{
    [DataContract, XmlRoot("result")]
    public class PaymentResponse : BaseResponse
    {
        [DataMember, XmlElement("data")]
        public PaymentList Data { get; set; }
    }
}