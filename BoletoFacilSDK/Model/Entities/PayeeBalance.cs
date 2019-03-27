using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class PayeeBalance : BaseEntity
    {
        [DataMember, XmlElement("balance")]
        public decimal Balance { get; set; }
        [DataMember, XmlElement("withheldBalance")]
        public decimal WithheldBalance { get; set; }
        [DataMember, XmlElement("transferableBalance")]
        public decimal TransferableBalance { get; set; }
    }
}