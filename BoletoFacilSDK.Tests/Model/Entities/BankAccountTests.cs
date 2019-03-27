using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            BankAccount obj = new BankAccount();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.BankNumber);
            Assert.IsNull(obj.AgencyNumber);
            Assert.IsNull(obj.AccountNumber);
            Assert.IsNull(obj.BankAccountType);
            Assert.IsNull(obj.AccountComplementNumber);

            obj.BankNumber = "237";
            obj.AgencyNumber = "123";
            obj.AccountNumber = "4567";
            obj.BankAccountType = BankAccountType.SAVINGS;
            obj.AccountComplementNumber = int.MaxValue;
            Assert.AreEqual("237", obj.BankNumber);
            Assert.AreEqual("123", obj.AgencyNumber);
            Assert.AreEqual("4567", obj.AccountNumber);
            Assert.AreEqual(BankAccountType.SAVINGS, obj.BankAccountType);
            Assert.AreEqual(int.MaxValue, obj.AccountComplementNumber);
        }
    }
}
