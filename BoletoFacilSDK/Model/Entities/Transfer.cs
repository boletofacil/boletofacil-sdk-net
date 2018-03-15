using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class Transfer : BaseEntity
    {
        [DataMember, XmlElement("amount")]
        public decimal? Amount { get; set; }
    }
}