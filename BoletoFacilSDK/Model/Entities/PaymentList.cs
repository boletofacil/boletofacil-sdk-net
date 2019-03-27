using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Entities
{
    [DataContract]
    public class PaymentList : BaseEntity
    {
        [DataMember, XmlElement("payment")]
        public Payment Payment { get; set; }

    }
}
