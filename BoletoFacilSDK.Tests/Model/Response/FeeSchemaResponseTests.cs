using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Tests.Model.Response
{
    [TestClass]
    public class FeeSchemaResponseTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            FeeSchemaResponse obj = new FeeSchemaResponse();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Data);

            obj.Data = new FeeSchema();
            Assert.IsNotNull(obj.Data);
            Assert.IsNotNull(obj.ToJson());
        }
    }
}
