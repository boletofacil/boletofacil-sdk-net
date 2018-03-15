using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BoletoFacilSDK.Model.Response
{
    [DataContract, XmlRoot("result")]
    public class TransferResponse : BaseResponse
    {
    }
}