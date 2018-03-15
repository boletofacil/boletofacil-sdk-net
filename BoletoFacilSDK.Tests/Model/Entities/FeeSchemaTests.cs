using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class FeeSchemaTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            FeeSchema obj = new FeeSchema();

            Assert.IsNotNull(obj);
            Assert.AreEqual(0, obj.Id);
            Assert.IsNull(obj.FeeSchemaToken);

            obj.Id = long.MaxValue;
            obj.FeeSchemaToken = "TOKEN12345";
            Assert.AreEqual(long.MaxValue, obj.Id);
            Assert.AreEqual("TOKEN12345", obj.FeeSchemaToken);
        }
    }
}
