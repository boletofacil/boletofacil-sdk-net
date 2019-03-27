using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Discount : BaseEntity
    {
        [DataMember, XmlElement("amount")]
        public decimal Amount { get; set; }
        [DataMember, XmlElement("days")]
        public int Days { get; set; }
    }
}