using System;
using BoletoFacilSDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoletoFacilSDK.Tests.Exceptions
{
    [TestClass]
    public class BoletoFacilMethodNotAllowedExceptionTests : AbstractTests
    {
        [TestMethod]
        public void Constructor()
        {
            // Arrange
            const string message = "Teste de exceção";

            try
            {
                // Act
                throw new BoletoFacilMethodNotAllowedException(message);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilMethodNotAllowedException));
                Assert.AreEqual("Teste de exceção", ex.Message);
                Assert.AreEqual(405, ((BoletoFacilMethodNotAllowedException)ex).HTTPStatusCode);
                Assert.IsNull(ex.InnerException);
            }
        }
    }
}
