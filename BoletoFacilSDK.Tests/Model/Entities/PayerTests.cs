using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class PayerTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Payer obj = new Payer();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Email);
            Assert.IsNull(obj.SecondaryEmail);
            Assert.IsNull(obj.Phone);

            obj.Email = "email@email.com";
            obj.SecondaryEmail = "email2@email.com";
            obj.Phone = "(11) 99876-5432";
            Assert.AreEqual("email@email.com", obj.Email);
            Assert.AreEqual("email2@email.com", obj.SecondaryEmail);
            Assert.AreEqual("(11) 99876-5432", obj.Phone);
        }
    }
}
