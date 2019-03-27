using System;
using BoletoFacilSDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoletoFacilSDK.Tests.Exceptions
{
    [TestClass]
    public class BoletoFacilTokenExceptionTests : AbstractTests
    {
        [TestMethod]
        public void Constructor1()
        {
            // Arrange
            const string message = "Teste de exceção";

            try
            {
                // Act
                throw new BoletoFacilTokenException(message);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilTokenException));
                Assert.AreEqual(message, ex.Message);
                Assert.IsNull(ex.InnerException);
            }
        }

        [TestMethod]
        public void Constructor2()
        {
            // Arrange
            const string message = "Teste de exceção";

            try
            {
                try
                {
                    throw new ArgumentException("Exceção interna");
                }
                catch (Exception inner)
                {
                    // Act
                    throw new BoletoFacilTokenException(message, inner);
                }
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilTokenException));
                Assert.AreEqual(message, ex.Message);
                Assert.IsNotNull(ex.InnerException);
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentException));
            }
        }
    }
}
