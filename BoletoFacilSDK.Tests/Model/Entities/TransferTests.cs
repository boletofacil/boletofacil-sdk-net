using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class TransferTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Transfer obj = new Transfer();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Amount);

            obj.Amount = decimal.MaxValue;
            Assert.AreEqual(decimal.MaxValue, obj.Amount);
        }
    }
}
