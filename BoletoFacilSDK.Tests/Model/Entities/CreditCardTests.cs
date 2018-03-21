using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class CreditCardTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            CreditCard obj = new CreditCard();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Number);
            Assert.IsNull(obj.HolderName);
            Assert.IsNull(obj.SecurityCode);
            Assert.IsNull(obj.ExpirationMonth);
            Assert.IsNull(obj.ExpirationYear);

            obj.Number = "5480452215505109";
            obj.HolderName = "Fulano da Silva";
            obj.SecurityCode = int.MaxValue;
            obj.ExpirationMonth = int.MaxValue;
            obj.ExpirationYear = int.MaxValue;
            Assert.AreEqual("5480452215505109", obj.Number);
            Assert.AreEqual("Fulano da Silva", obj.HolderName);
            Assert.AreEqual(int.MaxValue, obj.SecurityCode);
            Assert.AreEqual(int.MaxValue, obj.ExpirationMonth);
            Assert.AreEqual(int.MaxValue, obj.ExpirationYear);
        }
    }
}
