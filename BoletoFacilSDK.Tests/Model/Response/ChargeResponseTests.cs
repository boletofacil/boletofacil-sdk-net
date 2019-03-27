using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Tests.Model.Response
{
    [TestClass]
    public class ChargeResponseTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            ChargeResponse obj = new ChargeResponse();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Data);

            obj.Data = new ChargeList();
            Assert.IsNotNull(obj.Data);

            obj.Data.Charges = new Charge[1];
            obj.Data.Charges[0] = new Charge();

            Assert.IsNotNull(obj.ToJson());
        }
    }
}
