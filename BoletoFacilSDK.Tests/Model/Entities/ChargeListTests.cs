using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class ChargeListTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            ChargeList obj = new ChargeList();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Charges);

            obj.Charges = new Charge[1];
            Assert.IsNotNull(obj.Charges);
        }
    }
}
