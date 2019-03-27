using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities.Enums
{
    [TestClass]
    public class PaymentStatusTests
    {
        [TestMethod]
        public void Values()
        {
            Assert.AreEqual("AUTHORIZED", PaymentStatus.AUTHORIZED.ToString());
            Assert.AreEqual("AWAITING_PROCESSING", PaymentStatus.AWAITING_PROCESSING.ToString());
            Assert.AreEqual("BANK_PAID_BACK", PaymentStatus.BANK_PAID_BACK.ToString());
            Assert.AreEqual("CONFIRMED", PaymentStatus.CONFIRMED.ToString());
            Assert.AreEqual("CUSTOMER_PAID_BACK", PaymentStatus.CUSTOMER_PAID_BACK.ToString());
            Assert.AreEqual("DECLINED", PaymentStatus.DECLINED.ToString());
            Assert.AreEqual("FAILED", PaymentStatus.FAILED.ToString());
            Assert.AreEqual("NOT_AUTHORIZED", PaymentStatus.NOT_AUTHORIZED.ToString());
        }
    }
}
