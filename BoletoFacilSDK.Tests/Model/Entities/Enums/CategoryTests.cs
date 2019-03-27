using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities.Enums
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Values()
        {
            Assert.AreEqual("RETAIL", Category.RETAIL.ToString());
            Assert.AreEqual("FOOD", Category.FOOD.ToString());
            Assert.AreEqual("HEALTH_AND_BEAUTY", Category.HEALTH_AND_BEAUTY.ToString());
            Assert.AreEqual("SERVICES", Category.SERVICES.ToString());
            Assert.AreEqual("TECHNOLOGY", Category.TECHNOLOGY.ToString());
            Assert.AreEqual("ENTERTAINMENT", Category.ENTERTAINMENT.ToString());
            Assert.AreEqual("ECOMMERCE", Category.ECOMMERCE.ToString());
            Assert.AreEqual("OTHER", Category.OTHER.ToString());
        }
    }
}
