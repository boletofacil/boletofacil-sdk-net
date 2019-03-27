using System.Runtime.Serialization;
using System.Xml.Serialization;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Model.Response
{
    [DataContract, XmlRoot("result")]
    public class ListChargesResponse : BaseResponse
    {
        [DataMember, XmlElement("data")]
        public ChargeList Data { get; set; }
    }
}