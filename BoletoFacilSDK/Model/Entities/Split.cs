using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Split : BaseEntity
    {
        [DataMember, XmlElement("splitFixed")]
        public decimal SplitFixed { get; set; }
        [DataMember, XmlElement("splitVariable")]
        public decimal SplitVariable { get; set; }
        [DataMember, XmlElement("splitTriggerAmount")]
        public decimal SplitTriggerAmount { get; set; }
    }
}
