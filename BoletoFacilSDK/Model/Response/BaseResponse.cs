using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Response
{
    [DataContract]
    public class BaseResponse : ModelBase
    {
        [DataMember, XmlElement("success")]
        public bool Success { get; set; }    
    }
}