using System.Runtime.Serialization;
using System.Xml.Serialization;
using BoletoFacilSDK.Model.Entities.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class BankAccount : BaseEntity
    {
        [DataMember, XmlElement("bankNumber")]
        public string BankNumber { get; set; }
        [DataMember, XmlElement("agencyNumber")]
        public string AgencyNumber { get; set; }
        [DataMember, XmlElement("accountNumber")]
        public string AccountNumber { get; set; }
        [DataMember, XmlElement("bankAccountType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BankAccountType? BankAccountType { get; set; }
        [DataMember, XmlElement("accountComplementNumber")]
        public int? AccountComplementNumber { get; set; }
    }
}
