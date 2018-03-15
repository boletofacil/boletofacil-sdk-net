using System;
using System.Runtime.Serialization;

namespace BoletoFacilSDK.Model.Request
{
    [DataContract]
    public class ListChargesDates : BaseRequest
    {
        [DataMember]
        public DateTime? BeginDueDate { get; set; }
        [DataMember]
        public DateTime? EndDueDate { get; set; }
        [DataMember]
        public DateTime? BeginPaymentDate { get; set; }
        [DataMember]
        public DateTime? EndPaymentDate { get; set; }
    }
}