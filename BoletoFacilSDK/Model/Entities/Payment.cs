using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using BoletoFacilSDK.Model.Entities.Enums;
using Newtonsoft.Json.Converters;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract, XmlRoot("payment")]
    public class Payment : BaseEntity
    {
        [DataMember, XmlElement("id")]
        public long? Id { get; set; }

        [DataMember, XmlElement("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("date"), XmlIgnore, JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? Date { get; set; }

        [DataMember, XmlElement("fee")]
        public decimal? Fee { get; set; }

        [DataMember, XmlElement("type"), JsonConverter(typeof(StringEnumConverter))]
        public PaymentType? Type { get; set; }

        [DataMember, XmlElement("status"), JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus? Status { get; set; }

        [JsonIgnore, DataMember, XmlElement("date")]
        public string DateString
        {
            get { return Date?.ToString("dd/MM/yyyy"); }
            set { Date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
        }
    }
}