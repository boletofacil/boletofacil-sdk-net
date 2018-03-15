using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class SplitTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Split obj = new Split();

            Assert.IsNotNull(obj);
            Assert.AreEqual(0, obj.SplitFixed);
            Assert.AreEqual(0, obj.SplitVariable);
            Assert.AreEqual(0, obj.SplitTriggerAmount);

            obj.SplitFixed = decimal.MaxValue;
            obj.SplitVariable = decimal.MaxValue;
            obj.SplitTriggerAmount = decimal.MaxValue;
            Assert.AreEqual(decimal.MaxValue, obj.SplitFixed);
            Assert.AreEqual(decimal.MaxValue, obj.SplitVariable);
            Assert.AreEqual(decimal.MaxValue, obj.SplitTriggerAmount);
        }
    }
}
