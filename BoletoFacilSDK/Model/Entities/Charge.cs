using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Charge : BaseEntity
    {
        [XmlElement("description"), XmlIgnore]
        public string Description { get; set; }
        [XmlElement("reference"), XmlIgnore]
        public string Reference { get; set; }
        [XmlElement("amount"), XmlIgnore]
        public decimal? Amount { get; set; }
        [JsonProperty("dueDate"), XmlIgnore, JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime DueDate { get; set; }
        [XmlElement("installments"), XmlIgnore]
        public int? Installments { get; set; }
        [XmlElement("maxOverdueDays"), XmlIgnore]
        public int? MaxOverdueDays { get; set; }
        [XmlElement("fine"), XmlIgnore]
        public decimal? Fine { get; set; }
        [XmlElement("interest"), XmlIgnore]
        public decimal? Interest { get; set; }
        [XmlElement("discount"), XmlIgnore]
        public Discount Discount { get; set; }
        [XmlElement("payer"), XmlIgnore]
        public Payer Payer { get; set; }
        [XmlElement("billingAddress"), XmlIgnore]
        public Address BillingAddress { get; set; }
        [XmlElement("notifyPayer"), XmlIgnore]
        public bool? NotifyPayer { get; set; }
        [XmlElement("notificationUrl"), XmlIgnore]
        public string NotificationUrl { get; set; }
        [XmlElement("referralToken"), XmlIgnore]
        public string ReferralToken { get; set; }
        [XmlElement("feeSchemaToken"), XmlIgnore]
        public string FeeSchemaToken { get; set; }
        [XmlElement("splitRecipient"), XmlIgnore]
        public string SplitRecipient { get; set; }
        [DataMember, XmlElement("code")]
        public string Code { get; set; }
        [DataMember, XmlElement("link")]
        public string Link { get; set; }
        [DataMember, XmlElement("payNumber")]
        public string PayNumber { get; set; }
        [DataMember, XmlElement("checkoutUrl")]
        public string CheckoutUrl { get; set; }
        [DataMember, XmlElement("billetDetails")]
        public BilletDetails BilletDetails { get; set; }
        [DataMember, XmlArray("payments"), XmlArrayItem("payment")]
        public Payment[] Payments { get; set; }

        [JsonIgnore, DataMember, XmlElement("dueDate")]
        public string DueDateString
        {
            get { return DueDate.ToString("dd/MM/yyyy"); }
            set { DueDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
        }
    }
}