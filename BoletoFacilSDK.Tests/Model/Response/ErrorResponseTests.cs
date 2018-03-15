using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Tests.Model.Response
{
    [TestClass]
    public class ErrorResponseTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            ErrorResponse obj = new ErrorResponse();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.ErrorMessage);

            obj.ErrorMessage = "erro";
            Assert.AreEqual("erro", obj.ErrorMessage);
        }
    }
}
