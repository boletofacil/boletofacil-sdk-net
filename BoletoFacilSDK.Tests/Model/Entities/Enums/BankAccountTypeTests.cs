using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities.Enums
{
    [TestClass]
    public class BankAccountTypeTests
    {
        [TestMethod]
        public void Values()
        {
            Assert.AreEqual("CHECKING", BankAccountType.CHECKING.ToString());
            Assert.AreEqual("SAVINGS", BankAccountType.SAVINGS.ToString());
        }
    }
}
