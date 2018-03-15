using System;
using BoletoFacilSDK.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoletoFacilSDK.Tests.Exceptions
{
    [TestClass]
    public class BoletoFacilExceptionTests : AbstractTests
    {
        [TestMethod]
        public void Constructor1()
        {
            // Arrange

            try
            {
                // Act
                throw new BoletoFacilException();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilException));
                Assert.IsTrue(ex.Message.Contains("BoletoFacilSDK.Exceptions.BoletoFacilException"));
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
                // Act
                throw new BoletoFacilException(message);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilException));
                Assert.AreEqual(message, ex.Message);
                Assert.IsNull(ex.InnerException);
            }
        }

        [TestMethod]
        public void Constructor3()
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
                    throw new BoletoFacilException(message, inner);
                }
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilException));
                Assert.AreEqual(message, ex.Message);
                Assert.IsNotNull(ex.InnerException);
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentException));
            }
        }
    }
}
