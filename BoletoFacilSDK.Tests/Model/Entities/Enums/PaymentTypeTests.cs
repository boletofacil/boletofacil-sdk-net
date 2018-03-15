using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities.Enums
{
    [TestClass]
    public class PaymentTypeTests
    {
        [TestMethod]
        public void Values()
        {
            Assert.AreEqual("BOLETO", PaymentType.BOLETO.ToString());
            Assert.AreEqual("CREDIT_CARD", PaymentType.CREDIT_CARD.ToString());
            Assert.AreEqual("INSTALLMENT_CREDIT_CARD", PaymentType.INSTALLMENT_CREDIT_CARD.ToString());
        }
    }
}
