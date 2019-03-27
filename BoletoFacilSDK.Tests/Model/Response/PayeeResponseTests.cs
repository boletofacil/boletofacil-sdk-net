using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Tests.Model.Response
{
    [TestClass]
    public class PayeeResponseTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            PayeeResponse obj = new PayeeResponse();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Data);

            obj.Data = new Payee();
            Assert.IsNotNull(obj.Data);
            Assert.IsNotNull(obj.ToJson());
        }
    }
}
