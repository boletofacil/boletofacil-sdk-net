using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class CreditCard : BaseEntity
    {
        [DataMember, XmlElement("number")]
        public string Number { get; set; }
        [DataMember, XmlElement("holderName")]
        public string HolderName { get; set; }
        [DataMember, XmlElement("securityCode")]
        public int? SecurityCode { get; set; }
        [DataMember, XmlElement("expirationMonth")]
        public int? ExpirationMonth { get; set; }
        [DataMember, XmlElement("expirationYear")]
        public int? ExpirationYear { get; set; }
    }
}
