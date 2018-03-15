using System;
using BoletoFacilSDK.Exceptions;
using BoletoFacilSDK.Model.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoletoFacilSDK.Tests.Exceptions
{
    [TestClass]
    public class BoletoFacilRequestExceptionTests : AbstractTests
    {
        [TestMethod]
        public void Constructor1()
        {
            // Arrange
            const string message = "Teste de exceção";

            try
            {
                // Act
                throw new BoletoFacilRequestException(message);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilRequestException));
                Assert.AreEqual(message, ex.Message);
                Assert.IsNull(ex.InnerException);
            }
        }

        [TestMethod]
        public void Constructor2()
        {
            // Arrange
            const int httpStatusCode = 400;
            const string responseBody = "Teste de exceção";

            try
            {
                // Act
                throw new BoletoFacilRequestException(httpStatusCode, responseBody);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilRequestException));
                Assert.AreEqual(httpStatusCode, ((BoletoFacilRequestException)ex).HTTPStatusCode);
                Assert.IsNull(ex.InnerException);
            }
        }

        [TestMethod]
        public void Constructor3()
        {
            // Arrange
            const int httpStatusCode = 400;
            ErrorResponse response = new ErrorResponse();

            try
            {
                // Act
                throw new BoletoFacilRequestException(httpStatusCode, response);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilRequestException));
                Assert.AreEqual(httpStatusCode, ((BoletoFacilRequestException)ex).HTTPStatusCode);
                Assert.AreEqual(response, ((BoletoFacilRequestException)ex).Error);
                Assert.IsNull(ex.InnerException);
            }
        }
    }
}
