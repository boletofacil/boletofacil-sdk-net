using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Address obj = new Address();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Street);
            Assert.IsNull(obj.Number);
            Assert.IsNull(obj.Complement);
            Assert.IsNull(obj.Neighborhood);
            Assert.IsNull(obj.City);
            Assert.IsNull(obj.State);
            Assert.IsNull(obj.Postcode);

            obj.Street = "Rua Teste";
            obj.Number = "123";
            obj.Complement = "apto 11";
            obj.Neighborhood = "Centro";
            obj.City = "Sao Paulo";
            obj.State = "SP";
            obj.Postcode = "01010-100";
            Assert.AreEqual("Rua Teste", obj.Street);
            Assert.AreEqual("123", obj.Number);
            Assert.AreEqual("apto 11", obj.Complement);
            Assert.AreEqual("Centro", obj.Neighborhood);
            Assert.AreEqual("Sao Paulo", obj.City);
            Assert.AreEqual("SP", obj.State);
            Assert.AreEqual("01010-100", obj.Postcode);
        }
    }
}
