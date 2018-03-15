using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Payer : Person
    {
        [DataMember, XmlElement("email")]
        public string Email { get; set; }
        [DataMember, XmlElement("secondaryEmail")]
        public string SecondaryEmail { get; set; }
        [DataMember, XmlElement("phone")]
        public string Phone { get; set; }
    }
}