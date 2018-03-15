using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class PayeeTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Payee obj = new Payee();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.NotificationUrl);
            Assert.IsNull(obj.Email);
            Assert.IsNull(obj.Password);
            Assert.IsNull(obj.Phone);
            Assert.IsNull(obj.LinesOfBusiness);
            Assert.IsNull(obj.TradingName);
            Assert.IsNull(obj.Repr);
            Assert.IsNull(obj.AccountHolder);
            Assert.IsNull(obj.BankAccount);
            Assert.IsNull(obj.Category);
            Assert.IsNull(obj.CompanyType);
            Assert.IsNull(obj.Address);
            Assert.IsNull(obj.BusinessAreaId);
            Assert.IsNull(obj.EmailOptOut);
            Assert.IsNull(obj.AutoApprove);
            Assert.IsNull(obj.Token);
            Assert.IsNull(obj.Status);

            obj.NotificationUrl = "http://www.notification.br/url";
            obj.Email = "email@email.com";
            obj.Password = "Pass1word!";
            obj.Phone = "(11) 99876-5432";
            obj.LinesOfBusiness = "Areas de atuacao da empresa";
            obj.TradingName = "Nome fantasia";
            obj.Repr = new Person();
            obj.AccountHolder = new Person();
            obj.BankAccount = new BankAccount();
            obj.Category = Category.OTHER;
            obj.CompanyType = CompanyType.LTDA;
            obj.Address = new Address();
            obj.BusinessAreaId = int.MaxValue;
            obj.EmailOptOut = true;
            obj.AutoApprove = false;
            obj.Token = "TOKEN12345";
            obj.Status = "Approved";

            Assert.AreEqual("http://www.notification.br/url", obj.NotificationUrl);
            Assert.AreEqual("email@email.com", obj.Email);
            Assert.AreEqual("Pass1word!", obj.Password);
            Assert.AreEqual("(11) 99876-5432", obj.Phone);
            Assert.AreEqual("Areas de atuacao da empresa", obj.LinesOfBusiness);
            Assert.AreEqual("Nome fantasia", obj.TradingName);
            Assert.IsNotNull(obj.Repr);
            Assert.IsNotNull(obj.AccountHolder);
            Assert.IsNotNull(obj.BankAccount);
            Assert.AreEqual(Category.OTHER, obj.Category);
            Assert.AreEqual(CompanyType.LTDA, obj.CompanyType);
            Assert.IsNotNull(obj.Address);
            Assert.AreEqual(int.MaxValue, obj.BusinessAreaId);
            Assert.IsNotNull(obj.EmailOptOut);
            Assert.IsTrue(obj.EmailOptOut.Value);
            Assert.IsNotNull(obj.AutoApprove);
            Assert.IsFalse(obj.AutoApprove.Value);
            Assert.AreEqual("TOKEN12345", obj.Token);
            Assert.AreEqual("Approved", obj.Status);
        }
    }
}
