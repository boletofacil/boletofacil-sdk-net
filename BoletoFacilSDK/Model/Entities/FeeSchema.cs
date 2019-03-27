using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class FeeSchema : BaseEntity
    {
        [DataMember, XmlElement("id")]
        public long Id { get; set; }
        [DataMember, XmlElement("feeSchemaToken")]
        public string FeeSchemaToken { get; set; }
    }
}
