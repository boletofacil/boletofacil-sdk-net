using System.Runtime.Serialization;
using System.Xml.Serialization;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Model.Response
{
    [DataContract, XmlRoot("result")]
    public class FetchBalanceResponse : BaseResponse
    {
        [DataMember, XmlElement("data")]
        public PayeeBalance Data { get; set; }
    }
}