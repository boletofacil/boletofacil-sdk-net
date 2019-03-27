using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities.Enums
{
    [TestClass]
    public class CompanyTypeTests
    {
        [TestMethod]
        public void Values()
        {
            Assert.AreEqual("MEI", CompanyType.MEI.ToString());
            Assert.AreEqual("EI", CompanyType.EI.ToString());
            Assert.AreEqual("EIRELI", CompanyType.EIRELI.ToString());
            Assert.AreEqual("LTDA", CompanyType.LTDA.ToString());
            Assert.AreEqual("INSTITUTION_NGO_ASSOCIATION", CompanyType.INSTITUTION_NGO_ASSOCIATION.ToString());
        }
    }
}
