using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Person : BaseEntity
    {
        [DataMember, XmlElement("name")]
        public string Name { get; set; }
        [DataMember, XmlElement("cpfCnpj")]
        public string CpfCnpj { get; set; }
        [XmlIgnore, JsonProperty("birthDate"), JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? BirthDate { get; set; }

        [JsonIgnore, DataMember, XmlElement("birthDate")]
        public string BirthDateString
        {
            get { return BirthDate?.ToString("dd/MM/yyyy"); }
            set { BirthDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
        }
    }
}
