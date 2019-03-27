using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class BilletDetails : BaseEntity
    {
        [DataMember, XmlElement("bankAccount")]
        public string BankAccount { get; set; }
        [DataMember, XmlElement("ourNumber")]
        public string OurNumber { get; set; }
        [DataMember, XmlElement("barcodeNumber")]
        public string BarcodeNumber { get; set; }
        [DataMember, XmlElement("portfolio")]
        public string Portfolio { get; set; }
    }
}
