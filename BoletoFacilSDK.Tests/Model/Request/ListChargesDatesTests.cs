using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Request;

namespace BoletoFacilSDK.Tests.Model.Request
{
    [TestClass]
    public class ListChargesDatesTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            ListChargesDates obj = new ListChargesDates();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.BeginDueDate);
            Assert.IsNull(obj.EndDueDate);
            Assert.IsNull(obj.BeginPaymentDate);
            Assert.IsNull(obj.EndPaymentDate);
			Assert.IsNull(obj.BeginPaymentConfirmation);
			Assert.IsNull(obj.EndPaymentConfirmation);

            obj.BeginDueDate = DateTime.MinValue;
            obj.EndDueDate = DateTime.MaxValue;
            obj.BeginPaymentDate = DateTime.MinValue;
            obj.EndPaymentDate = DateTime.MaxValue;
			obj.BeginPaymentConfirmation = DateTime.MinValue;
			obj.EndPaymentConfirmation = DateTime.MaxValue;
            Assert.AreEqual(DateTime.MinValue, obj.BeginDueDate);
            Assert.AreEqual(DateTime.MaxValue, obj.EndDueDate);
            Assert.AreEqual(DateTime.MinValue, obj.BeginPaymentDate);
            Assert.AreEqual(DateTime.MaxValue, obj.EndPaymentDate);
			Assert.AreEqual(DateTime.MinValue, obj.BeginPaymentConfirmation);
			Assert.AreEqual(DateTime.MaxValue, obj.EndPaymentConfirmation);
        }
    }
}
