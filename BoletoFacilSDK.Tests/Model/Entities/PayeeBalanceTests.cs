using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class PayeeBalanceTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            PayeeBalance obj = new PayeeBalance();

            Assert.IsNotNull(obj);
            Assert.AreEqual(0, obj.Balance);
            Assert.AreEqual(0, obj.WithheldBalance);
            Assert.AreEqual(0, obj.TransferableBalance);

            obj.Balance = decimal.MaxValue;
            obj.WithheldBalance = decimal.MaxValue;
            obj.TransferableBalance = decimal.MaxValue;
            Assert.AreEqual(decimal.MaxValue, obj.Balance);
            Assert.AreEqual(decimal.MaxValue, obj.WithheldBalance);
            Assert.AreEqual(decimal.MaxValue, obj.TransferableBalance);
        }
    }
}
