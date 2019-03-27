using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Entities.Enums;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class ChargeTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Charge obj = new Charge();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Description);
            Assert.IsNull(obj.Reference);
            Assert.IsNull(obj.Amount);
            Assert.AreEqual(DateTime.MinValue, obj.DueDate);
            Assert.IsNull(obj.Installments);
            Assert.IsNull(obj.MaxOverdueDays);
            Assert.IsNull(obj.Fine);
            Assert.IsNull(obj.Interest);
            Assert.IsNull(obj.Discount);
            Assert.IsNull(obj.Payer);
            Assert.IsNull(obj.BillingAddress);
            Assert.IsNull(obj.NotifyPayer);
            Assert.IsNull(obj.NotificationUrl);
            Assert.IsNull(obj.ReferralToken);
            Assert.IsNull(obj.FeeSchemaToken);
            Assert.IsNull(obj.SplitRecipient);
            Assert.IsNull(obj.PaymentTypes);
            Assert.IsNull(obj.CreditCard);
            Assert.IsNull(obj.PaymentAdvance);
			Assert.IsNull(obj.CreditCardHash);
            Assert.IsNull(obj.Code);
            Assert.IsNull(obj.Link);
            Assert.IsNull(obj.PayNumber);
            Assert.IsNull(obj.CheckoutUrl);
            Assert.IsNull(obj.BilletDetails);
            Assert.IsNull(obj.Payments);
            Assert.AreEqual($"{DateTime.MinValue:dd/MM/yyyy}", obj.DueDateString);

            obj.Description = "Charge description";
            obj.Reference = "Reference number";
            obj.Amount = decimal.MaxValue;
            obj.DueDate = DateTime.Today;
            obj.Installments = int.MaxValue;
            obj.MaxOverdueDays = int.MaxValue;
            obj.Fine = decimal.MaxValue;
            obj.Interest = decimal.MaxValue;
            obj.Discount = new Discount();
            obj.Payer = new Payer();
            obj.BillingAddress = new Address();
            obj.NotifyPayer = true;
            obj.NotificationUrl = "http://www.notification.br/url";
            obj.ReferralToken = "ABC123";
            obj.FeeSchemaToken = "XPTO7890";
            obj.SplitRecipient = "123.456.789-00";
            obj.PaymentTypes = new PaymentType[1];
            obj.CreditCard = new CreditCard();
            obj.PaymentAdvance = false;
			obj.CreditCardHash = "HASH11223344";
            obj.Code = "11223344";
            obj.Link = "https://www.boletobancario.com/link";
            obj.PayNumber = "23700.123456.789123.546543.79810000012345";
            obj.CheckoutUrl = "https://www.boletobancario.com/checkout";
            obj.BilletDetails = new BilletDetails();
            obj.Payments = new Payment[1];
            obj.DueDateString = $"{DateTime.Today:dd/MM/yyyy}";

            Assert.AreEqual("Charge description", obj.Description);
            Assert.AreEqual("Reference number", obj.Reference);
            Assert.AreEqual(decimal.MaxValue, obj.Amount);
            Assert.AreEqual(DateTime.Today, obj.DueDate);
            Assert.AreEqual(int.MaxValue, obj.Installments);
            Assert.AreEqual(int.MaxValue, obj.MaxOverdueDays);
            Assert.AreEqual(decimal.MaxValue, obj.Fine);
            Assert.AreEqual(decimal.MaxValue, obj.Interest);
            Assert.IsNotNull(obj.Discount);
            Assert.IsNotNull(obj.Payer);
            Assert.IsNotNull(obj.BillingAddress);
            Assert.IsNotNull(obj.NotifyPayer);
            Assert.IsTrue(obj.NotifyPayer.Value);
            Assert.AreEqual("http://www.notification.br/url", obj.NotificationUrl);
            Assert.AreEqual("ABC123", obj.ReferralToken);
            Assert.AreEqual("XPTO7890", obj.FeeSchemaToken);
            Assert.AreEqual("123.456.789-00", obj.SplitRecipient);
            Assert.IsNotNull(obj.PaymentTypes);
            Assert.IsNotNull(obj.CreditCard);
            Assert.IsNotNull(obj.PaymentAdvance);
            Assert.IsFalse(obj.PaymentAdvance.Value);
			Assert.AreEqual("HASH11223344", obj.CreditCardHash);
			Assert.AreEqual("11223344", obj.Code);
            Assert.AreEqual("https://www.boletobancario.com/link", obj.Link);
            Assert.AreEqual("23700.123456.789123.546543.79810000012345", obj.PayNumber);
            Assert.AreEqual("https://www.boletobancario.com/checkout", obj.CheckoutUrl);
            Assert.IsNotNull(obj.BilletDetails);
            Assert.IsNotNull(obj.Payments);
            Assert.AreEqual($"{DateTime.Today:dd/MM/yyyy}", obj.DueDateString);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Charge obj = new Charge();

            obj.Description = "Charge description";
            obj.Reference = "Reference number";
            obj.Amount = decimal.MaxValue;
            obj.DueDate = new DateTime(2018, 2, 17);
            obj.Installments = int.MaxValue;
            obj.MaxOverdueDays = int.MaxValue;
            obj.Fine = decimal.MaxValue;
            obj.Interest = decimal.MaxValue;
            obj.Discount = new Discount();
            obj.Payer = new Payer();
            obj.BillingAddress = new Address();
            obj.NotifyPayer = true;
            obj.NotificationUrl = "http://www.notification.br/url";
            obj.ReferralToken = "ABC123";
            obj.FeeSchemaToken = "XPTO7890";
            obj.SplitRecipient = "123.456.789-00";
            obj.PaymentTypes = new PaymentType[] { PaymentType.BOLETO, PaymentType.CREDIT_CARD };
            obj.CreditCard = new CreditCard();
            obj.PaymentAdvance = false;
			obj.CreditCardHash = "HASH11223344";
            obj.Code = "11223344";
            obj.Link = "https://www.boletobancario.com/link";
            obj.PayNumber = "23700.123456.789123.546543.79810000012345";
            obj.CheckoutUrl = "https://www.boletobancario.com/checkout";

            BilletDetails billetDetails = new BilletDetails();
            billetDetails.BankAccount = "1234-0 / 9438905";
            billetDetails.OurNumber = "000010083241 5";
            billetDetails.BarcodeNumber = "03393744100000176459694818900001008324150102";
            billetDetails.Portfolio = "CARTEIRA DE COB.";
            obj.BilletDetails = billetDetails;

            obj.Payments = new Payment[2];
            Payment payment1 = new Payment();
            payment1.Id = long.MaxValue;
            payment1.Amount = decimal.MaxValue;
            payment1.Date = new DateTime(2018, 2, 17);
            payment1.Fee = decimal.MaxValue;
            payment1.Type = PaymentType.CREDIT_CARD;
            payment1.Status = PaymentStatus.DECLINED;
            obj.Payments[0] = payment1;
            Payment payment2 = new Payment();
            payment2.Id = long.MaxValue;
            payment2.Amount = decimal.MaxValue;
            payment2.Date = new DateTime(2018, 2, 17);
            payment2.Fee = decimal.MaxValue;
            payment2.Type = PaymentType.BOLETO;
            payment2.Status = PaymentStatus.CONFIRMED;
            obj.Payments[1] = payment2;

            Assert.AreEqual("Description: Charge description" + Environment.NewLine +
                            "Reference: Reference number" + Environment.NewLine +
                            "Amount: 79228162514264337593543950335" + Environment.NewLine +
                            "DueDate: 17/02/2018" + Environment.NewLine +
                            "Installments: 2147483647" + Environment.NewLine +
                            "MaxOverdueDays: 2147483647" + Environment.NewLine +
                            "Fine: 79228162514264337593543950335" + Environment.NewLine +
                            "Interest: 79228162514264337593543950335" + Environment.NewLine +
                            "Discount: Amount: 0" + Environment.NewLine +
                            "Days: 0" + Environment.NewLine + Environment.NewLine +
                            "Payer: Email: " + Environment.NewLine +
                            "SecondaryEmail: " + Environment.NewLine +
                            "Phone: " + Environment.NewLine +
                            "Name: " + Environment.NewLine +
                            "CpfCnpj: " + Environment.NewLine +
                            "BirthDate: " + Environment.NewLine + Environment.NewLine +
                            "BillingAddress: Street: " + Environment.NewLine +
                            "Number: " + Environment.NewLine +
                            "Complement: " + Environment.NewLine +
                            "Neighborhood: " + Environment.NewLine +
                            "City: " + Environment.NewLine +
                            "State: " + Environment.NewLine +
                            "Postcode: " + Environment.NewLine + Environment.NewLine +
                            "NotifyPayer: True" + Environment.NewLine +
                            "NotificationUrl: http://www.notification.br/url" + Environment.NewLine +
                            "ReferralToken: ABC123" + Environment.NewLine +
                            "FeeSchemaToken: XPTO7890" + Environment.NewLine +
                            "SplitRecipient: 123.456.789-00" + Environment.NewLine +
                            "PaymentTypes: [" + Environment.NewLine +
                            "BOLETO," + Environment.NewLine +
                            "CREDIT_CARD] " + Environment.NewLine +
                            "CreditCard: Number: " + Environment.NewLine +
                            "HolderName: " + Environment.NewLine +
                            "SecurityCode: " + Environment.NewLine +
                            "ExpirationMonth: " + Environment.NewLine +
                            "ExpirationYear: " + Environment.NewLine + Environment.NewLine +
                            "PaymentAdvance: False" + Environment.NewLine +
			                "CreditCardHash: HASH11223344" + Environment.NewLine +
                            "Code: 11223344" + Environment.NewLine +
                            "Link: https://www.boletobancario.com/link" + Environment.NewLine +
                            "PayNumber: 23700.123456.789123.546543.79810000012345" + Environment.NewLine +
                            "CheckoutUrl: https://www.boletobancario.com/checkout" + Environment.NewLine +
                            "BilletDetails: BankAccount: 1234-0 / 9438905" + Environment.NewLine +
                            "OurNumber: 000010083241 5" + Environment.NewLine +
                            "BarcodeNumber: 03393744100000176459694818900001008324150102" + Environment.NewLine +
                            "Portfolio: CARTEIRA DE COB." + Environment.NewLine + Environment.NewLine +
                            "Payments: [" + Environment.NewLine +
                            "Id: 9223372036854775807" + Environment.NewLine +
                            "Amount: 79228162514264337593543950335" + Environment.NewLine +
                            "Date: 17/02/2018" + Environment.NewLine +
                            "Fee: 79228162514264337593543950335" + Environment.NewLine +
                            "Type: CREDIT_CARD" + Environment.NewLine +
                            "Status: DECLINED" + Environment.NewLine +
                            "," + Environment.NewLine +
                            "Id: 9223372036854775807" + Environment.NewLine +
                            "Amount: 79228162514264337593543950335" + Environment.NewLine +
                            "Date: 17/02/2018" + Environment.NewLine +
                            "Fee: 79228162514264337593543950335" + Environment.NewLine +
                            "Type: BOLETO" + Environment.NewLine +
                            "Status: CONFIRMED" + Environment.NewLine +
                            "] " + Environment.NewLine, obj.ToString());
        }
    }
}
