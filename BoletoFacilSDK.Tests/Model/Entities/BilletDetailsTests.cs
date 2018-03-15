using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class BilletDetailsTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            BilletDetails obj = new BilletDetails();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.BankAccount);
            Assert.IsNull(obj.OurNumber);
            Assert.IsNull(obj.BarcodeNumber);
            Assert.IsNull(obj.Portfolio);

            obj.BankAccount = "1234-0 / 9438905";
            obj.OurNumber = "000010083241 5";
            obj.BarcodeNumber = "03393744100000176459694818900001008324150102";
            obj.Portfolio = "CARTEIRA DE COB.";
            Assert.AreEqual("1234-0 / 9438905", obj.BankAccount);
            Assert.AreEqual("000010083241 5", obj.OurNumber);
            Assert.AreEqual("03393744100000176459694818900001008324150102", obj.BarcodeNumber);
            Assert.AreEqual("CARTEIRA DE COB.", obj.Portfolio);
        }
    }
}
