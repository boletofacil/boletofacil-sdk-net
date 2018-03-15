using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Tests.Model.Response
{
    [TestClass]
    public class FetchBalanceResponseTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            FetchBalanceResponse obj = new FetchBalanceResponse();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Data);

            obj.Data = new PayeeBalance();
            Assert.IsNotNull(obj.Data);
        }
    }
}
