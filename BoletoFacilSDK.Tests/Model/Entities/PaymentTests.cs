using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class PaymentTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Payment obj = new Payment();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Id);
            Assert.IsNull(obj.Amount);
            Assert.IsNull(obj.Date);
            Assert.IsNull(obj.Fee);
            Assert.IsNull(obj.Type);
            Assert.IsNull(obj.Status);
            Assert.IsNull(obj.DateString);

            obj.Id = long.MaxValue;
            obj.Amount = decimal.MaxValue;
            obj.Date = DateTime.Today;
            obj.Fee = decimal.MaxValue;
            obj.Type = PaymentType.CREDIT_CARD;
            obj.Status = PaymentStatus.DECLINED;
            obj.DateString = $"{DateTime.Today:dd/MM/yyyy}";
            Assert.AreEqual(long.MaxValue, obj.Id);
            Assert.AreEqual(decimal.MaxValue, obj.Amount);
            Assert.AreEqual(DateTime.Today, obj.Date);
            Assert.AreEqual(decimal.MaxValue, obj.Fee);
            Assert.AreEqual(PaymentType.CREDIT_CARD, obj.Type);
            Assert.AreEqual(PaymentStatus.DECLINED, obj.Status);
            Assert.AreEqual($"{DateTime.Today:dd/MM/yyyy}", obj.DateString);
        }
    }
}
