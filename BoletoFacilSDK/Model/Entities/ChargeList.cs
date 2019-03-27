using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class ChargeList : BaseEntity
    {
        [DataMember, XmlArray("charges"), XmlArrayItem("charge")]
        public Charge[] Charges { get; set; }
    }
}