using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using BoletoFacilSDK.Model.Entities.Enums;
using Newtonsoft.Json.Converters;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Payee : Person
    {
        [XmlElement("notificationUrl"), XmlIgnore]
        public string NotificationUrl { get; set; }
        [XmlElement("email"), XmlIgnore]
        public string Email { get; set; }
        [XmlElement("password"), XmlIgnore]
        public string Password { get; set; }
        [XmlElement("phone"), XmlIgnore]
        public string Phone { get; set; }
        [XmlElement("linesOfBusiness"), XmlIgnore]
        public string LinesOfBusiness { get; set; }
        [XmlElement("tradingName"), XmlIgnore]
        public string TradingName { get; set; }
        [XmlElement("repr"), XmlIgnore]
        public Person Repr { get; set; }
        [XmlElement("accountHolder"), XmlIgnore]
        public Person AccountHolder { get; set; }
        [XmlElement("bankAccount"), XmlIgnore]
        public BankAccount BankAccount { get; set; }
        [XmlElement("category"), XmlIgnore]
        [JsonConverter(typeof(StringEnumConverter))]
        public Category? Category { get; set; }
        [XmlElement("companyType"), XmlIgnore]
        [JsonConverter(typeof(StringEnumConverter))]
        public CompanyType? CompanyType { get; set; }
        [XmlElement("address"), XmlIgnore]
        public Address Address { get; set; }
        [XmlElement("businessAreaId"), XmlIgnore]
        public int? BusinessAreaId { get; set; }
        [XmlElement("emailOptOut"), XmlIgnore]
        public bool? EmailOptOut { get; set; }
        [XmlElement("autoApprove"), XmlIgnore]
        public bool? AutoApprove { get; set; }

        [DataMember, XmlElement("token")]
        public string Token { get; set; }
        [DataMember, XmlElement("status")]
        public string Status { get; set; }
    }
}
