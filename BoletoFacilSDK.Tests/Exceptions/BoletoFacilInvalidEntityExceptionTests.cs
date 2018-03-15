using System;
using BoletoFacilSDK.Exceptions;
using BoletoFacilSDK.Model;
using BoletoFacilSDK.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoletoFacilSDK.Tests.Exceptions
{
    [TestClass]
    public class BoletoFacilInvalidEntityExceptionTests : AbstractTests
    {
        [TestMethod]
        public void Constructor1()
        {
            // Arrange
            ModelBase entity = new Person();

            try
            {
                // Act
                throw new BoletoFacilInvalidEntityException(entity);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilInvalidEntityException));
                Assert.AreEqual("Person inválido.", ex.Message);
                Assert.IsNull(ex.InnerException);
            }
        }

        [TestMethod]
        public void Constructor2()
        {
            // Arrange
            ModelBase entity = new Person();

            try
            {
                try
                {
                    throw new ArgumentException("Exceção interna");
                }
                catch (Exception inner)
                {
                    // Act
                    throw new BoletoFacilInvalidEntityException(entity, inner);
                }
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(BoletoFacilInvalidEntityException));
                Assert.AreEqual("Person inválido.", ex.Message);
                Assert.IsNotNull(ex.InnerException);
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentException));
            }
        }
    }
}
