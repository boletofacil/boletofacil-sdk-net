using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class DiscountTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Discount obj = new Discount();

            Assert.IsNotNull(obj);
            Assert.AreEqual(0, obj.Amount);
            Assert.AreEqual(0, obj.Days);

            obj.Amount = decimal.MaxValue;
            obj.Days = int.MaxValue;
            Assert.AreEqual(decimal.MaxValue, obj.Amount);
            Assert.AreEqual(int.MaxValue, obj.Days);
        }
    }
}
