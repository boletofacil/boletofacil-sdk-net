using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Charge : BaseEntity
    { 
        [DataMember, XmlElement("description"), ]
        public string Description { get; set; }
        [DataMember, XmlElement("reference"), ]
        public string Reference { get; set; }
        [DataMember, XmlElement("amount"), ]
        public decimal? Amount { get; set; }
        [DataMember, XmlElement("totalAmount"),]
        public decimal? TotalAmount { get; set; }
        [JsonProperty("dueDate"), JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime DueDate { get; set; }
        [DataMember, XmlElement("installments"), ]
        public int? Installments { get; set; }
        [DataMember, XmlElement("maxOverdueDays"), ]
        public int? MaxOverdueDays { get; set; }
        [DataMember, XmlElement("fine"), ]
        public decimal? Fine { get; set; }
        [DataMember, XmlElement("interest"), ]
        public decimal? Interest { get; set; }
        [DataMember, XmlElement("discount"), ]
        public Discount Discount { get; set; }
        [DataMember, XmlElement("payer"), ]
        public Payer Payer { get; set; }
        [DataMember, XmlElement("billingAddress"), ]
        public Address BillingAddress { get; set; }
        [DataMember, XmlElement("notifyPayer"), ]
        public bool? NotifyPayer { get; set; }
        [DataMember, XmlElement("notificationUrl"), ]
        public string NotificationUrl { get; set; }
        [DataMember, XmlElement("feeSchemaToken"), ]
        public string FeeSchemaToken { get; set; }
        [DataMember, XmlElement("splitRecipient"), ]
        public string SplitRecipient { get; set; }
        [DataMember, XmlElement("referralToken"),]
        public string ReferralToken { get; set; }
        [DataMember, XmlElement("paymentTypes"), ]
        public PaymentType[] PaymentTypes { get; set; }
        [DataMember, XmlElement("creditCard"), ]
        public CreditCard CreditCard { get; set; }
        [DataMember, XmlElement("paymentAdvance"), ]
        public bool? PaymentAdvance { get; set; }
		[DataMember, XmlElement("creditCardHash"), ]
		public string CreditCardHash { get; set; }
        [DataMember, XmlElement("creditCardStore"),]
        public bool? CreditCardStore { get; set; }
        [DataMember, XmlElement("creditCardId"),]
        public string CreditCardId { get; set; }


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