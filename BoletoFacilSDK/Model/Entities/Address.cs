using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Address : BaseEntity
    {
        [DataMember, XmlElement("street")]
        public string Street { get; set; }
        [DataMember, XmlElement("number")]
        public string Number { get; set; }
        [DataMember, XmlElement("complement")]
        public string Complement { get; set; }
        [DataMember, XmlElement("neighborhood")]
        public string Neighborhood { get; set; }
        [DataMember, XmlElement("city")]
        public string City { get; set; }
        [DataMember, XmlElement("state")]
        public string State { get; set; }
        [DataMember, XmlElement("postcode")]
        public string Postcode { get; set; }
    }
}