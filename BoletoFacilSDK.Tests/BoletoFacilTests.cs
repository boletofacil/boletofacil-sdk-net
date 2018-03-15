using BoletoFacilSDK.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Exceptions;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Entities.Enums;
using BoletoFacilSDK.Model.Request;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Tests
{
    [TestClass]
    public class BoletoFacilTests : AbstractTests
    {
        [TestMethod]
        public void Constructor()
        {
            BoletoFacil boletoFacil = new BoletoFacil(BoletoFacilEnvironment.Sandbox, "ABC");

            Assert.IsNotNull(boletoFacil);
            Assert.AreEqual(BoletoFacilEnvironment.Sandbox, boletoFacil.BoletoFacilEnvironment);
            Assert.AreEqual("ABC", boletoFacil.Token);
        }

        [TestMethod, ExpectedException(typeof(BoletoFacilTokenException))]
        public void ConstructorException()
        {
            new BoletoFacil(BoletoFacilEnvironment.Sandbox, "");
        }

        [TestMethod]
        public void SetProxy()
        {
            BoletoFacil boletoFacil = new BoletoFacil(BoletoFacilEnvironment.Sandbox, "ABC");

            Assert.IsNotNull(boletoFacil);
            Assert.IsFalse(boletoFacil.UseProxy);
            Assert.IsNull(boletoFacil.ProxyAddress);
            Assert.IsNull(boletoFacil.ProxyUsername);
            Assert.IsNull(boletoFacil.ProxyPassword);

            boletoFacil.SetProxy("http://localhost", "username", "password");
            Assert.IsTrue(boletoFacil.UseProxy);
            Assert.AreEqual("http://localhost", boletoFacil.ProxyAddress);
            Assert.AreEqual("username", boletoFacil.ProxyUsername);
            Assert.AreEqual("password", boletoFacil.ProxyPassword);
        }

        #region IssueCharge tests

        [TestMethod]
        public void IssueChargeUniqueMandatoryFields()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Charge charge = Charge;

            ChargeResponse response = boletoFacil.IssueCharge(charge);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.Charges.Length);
            Assert.IsInstanceOfType(response.Data.Charges[0], typeof(Charge));
            Assert.AreEqual("101", response.Data.Charges[0].Code);
            Assert.AreEqual(StartDate.Date, response.Data.Charges[0].DueDate.Date);
            Assert.AreEqual(BaseUrl, response.Data.Charges[0].Link.Substring(0, BaseUrl.Length));
            Assert.AreEqual("03399.63290 64000.001014 00236.601027 8 67150000025000", response.Data.Charges[0].PayNumber);
        }

        [TestMethod]
        public void IssueChargeCarnet()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Charge charge = Charge;
            charge.Installments = 3;

            ChargeResponse response = boletoFacil.IssueCharge(charge);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(3, response.Data.Charges.Length);
            Assert.IsInstanceOfType(response.Data.Charges[0], typeof(Charge));
            Assert.IsInstanceOfType(response.Data.Charges[1], typeof(Charge));
            Assert.IsInstanceOfType(response.Data.Charges[2], typeof(Charge));
            Assert.AreEqual("101", response.Data.Charges[0].Code);
            Assert.AreEqual("102", response.Data.Charges[1].Code);
            Assert.AreEqual("103", response.Data.Charges[2].Code);
            Assert.AreEqual(StartDate.Date, response.Data.Charges[0].DueDate.Date);
            Assert.AreEqual(StartDate.Date.AddMonths(1), response.Data.Charges[1].DueDate.Date);
            Assert.AreEqual(StartDate.Date.AddMonths(2), response.Data.Charges[2].DueDate.Date);
            Assert.AreEqual(BaseUrl, response.Data.Charges[0].Link.Substring(0, BaseUrl.Length));
            Assert.AreEqual(BaseUrl, response.Data.Charges[1].Link.Substring(0, BaseUrl.Length));
            Assert.AreEqual(BaseUrl, response.Data.Charges[2].Link.Substring(0, BaseUrl.Length));
            Assert.AreEqual("03399.63290 64000.001014 00236.601027 8 67150000004115", response.Data.Charges[0].PayNumber);
            Assert.AreEqual("03399.63290 64000.001014 00236.601027 8 67250000004115", response.Data.Charges[1].PayNumber);
            Assert.AreEqual("03399.63290 64000.001014 00236.601027 8 67350000004115", response.Data.Charges[2].PayNumber);
        }

        [TestMethod]
        public void IssueChargeWithProxy()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            boletoFacil.SetProxy("http://localhost", "username", "password");
            Assert.IsTrue(boletoFacil.UseProxy);
            Charge charge = Charge;

            ChargeResponse response = boletoFacil.IssueCharge(charge);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.Charges.Length);
            Assert.IsInstanceOfType(response.Data.Charges[0], typeof(Charge));
            Assert.AreEqual("101", response.Data.Charges[0].Code);
            Assert.AreEqual(StartDate.Date, response.Data.Charges[0].DueDate.Date);
            Assert.AreEqual(BaseUrl, response.Data.Charges[0].Link.Substring(0, BaseUrl.Length));
            Assert.AreEqual("03399.63290 64000.001014 00236.601027 8 67150000025000", response.Data.Charges[0].PayNumber);
        }

        [TestMethod]
        public void IssueChargeErrorInvalidAmount()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Charge charge = Charge;
            charge.Amount = 0;

            BoletoFacilRequestException response = AssertException<BoletoFacilRequestException>(() => boletoFacil.IssueCharge(charge));

            AssertError(response, "Valor mínimo para cobrança é de R$ 2,50");
        }

        [TestMethod]
        public void IssueChargeErrorNoPayer()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Charge charge = Charge;
            charge.Payer = null;

            BoletoFacilRequestException response = AssertException<BoletoFacilRequestException>(() => boletoFacil.IssueCharge(charge));

            AssertError(response, "Parâmetro obrigatório 'payerName' não está presente");
        }

        #endregion

        #region RequestTransfer tests

        [TestMethod]
        public void RequestTransferPartialBalance()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Transfer transfer = Transfer;
            transfer.Amount = 78.67m;

            TransferResponse response = boletoFacil.RequestTransfer(transfer);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void RequestTransferFullBalance()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Transfer transfer = Transfer;

            TransferResponse response = boletoFacil.RequestTransfer(transfer);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        #endregion

        #region ListCharges tests

        [TestMethod]
        public void ListCharges()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            ListChargesDates dates = ListChargesDates;

            ListChargesResponse response = boletoFacil.ListCharges(dates);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);

            Assert.AreEqual(3, response.Data.Charges.Length);

            Assert.IsInstanceOfType(response.Data.Charges[0], typeof(Charge));
            Assert.AreEqual("101", response.Data.Charges[0].Code);
            Assert.AreEqual(StartDate.Date, response.Data.Charges[0].DueDate.Date);
            Assert.AreEqual(BaseUrl, response.Data.Charges[0].Link.Substring(0, BaseUrl.Length));
            Assert.AreEqual("03399.63290 64000.001014 00236.601027 8 67150000025000", response.Data.Charges[0].PayNumber);
            Assert.AreEqual(1, response.Data.Charges[0].Payments.Length);
            Assert.IsInstanceOfType(response.Data.Charges[0].Payments[0], typeof(Payment));
            Assert.AreEqual(1113123, response.Data.Charges[0].Payments[0].Id);
            Assert.AreEqual(163.9m, response.Data.Charges[0].Payments[0].Amount);
            Assert.AreEqual(StartDate.Date, response.Data.Charges[0].Payments[0].Date);
            Assert.AreEqual(4.34m, response.Data.Charges[0].Payments[0].Fee);
            Assert.AreEqual(PaymentType.BOLETO, response.Data.Charges[0].Payments[0].Type);
            Assert.AreEqual(PaymentStatus.CONFIRMED, response.Data.Charges[0].Payments[0].Status);

            Assert.IsInstanceOfType(response.Data.Charges[1], typeof(Charge));
            Assert.AreEqual("102", response.Data.Charges[1].Code);
            Assert.AreEqual(StartDate.Date.AddDays(1), response.Data.Charges[1].DueDate);
            Assert.AreEqual(BaseUrl, response.Data.Charges[1].Link.Substring(0, BaseUrl.Length));
            Assert.AreEqual("03399.63290 64000.001024 00236.601027 3 67150000015000", response.Data.Charges[1].PayNumber);
            Assert.AreEqual(2, response.Data.Charges[1].Payments.Length);
            Assert.IsInstanceOfType(response.Data.Charges[1].Payments[0], typeof(Payment));
            Assert.AreEqual(1113124, response.Data.Charges[1].Payments[0].Id);
            Assert.AreEqual(1141.4m, response.Data.Charges[1].Payments[0].Amount);
            Assert.AreEqual(StartDate.Date.AddDays(1), response.Data.Charges[1].Payments[0].Date);
            Assert.AreEqual(27.8m, response.Data.Charges[1].Payments[0].Fee);
            Assert.AreEqual(PaymentType.BOLETO, response.Data.Charges[1].Payments[0].Type);
            Assert.AreEqual(PaymentStatus.CONFIRMED, response.Data.Charges[1].Payments[0].Status);
            Assert.IsInstanceOfType(response.Data.Charges[1].Payments[1], typeof(Payment));
            Assert.AreEqual(1113125, response.Data.Charges[1].Payments[1].Id);
            Assert.AreEqual(1141.5m, response.Data.Charges[1].Payments[1].Amount);
            Assert.AreEqual(StartDate.Date.AddDays(2), response.Data.Charges[1].Payments[1].Date);
            Assert.AreEqual(27.85m, response.Data.Charges[1].Payments[1].Fee);
            Assert.AreEqual(PaymentType.CREDIT_CARD, response.Data.Charges[1].Payments[1].Type);
            Assert.AreEqual(PaymentStatus.CONFIRMED, response.Data.Charges[1].Payments[1].Status);

            Assert.AreEqual("103", response.Data.Charges[2].Code);
            Assert.AreEqual(StartDate.Date.AddDays(1), response.Data.Charges[2].DueDate);
            Assert.AreEqual(BaseUrl, response.Data.Charges[2].Link.Substring(0, BaseUrl.Length));
            Assert.AreEqual("03399.63290 64000.001024 00236.601027 3 67150000014000", response.Data.Charges[2].PayNumber);
            Assert.AreEqual(0, response.Data.Charges[2].Payments.Length);
        }

        [TestMethod]
        public void ListChargesErrorNoDatesInformed()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            ListChargesDates dates = new ListChargesDates();

            BoletoFacilRequestException response = AssertException<BoletoFacilRequestException>(() => boletoFacil.ListCharges(dates));

            Assert.IsNotNull(response);
            Assert.AreEqual(400, response.HTTPStatusCode);
            Assert.IsFalse(response.Error.Success);
            Assert.AreEqual("Favor informar a data de início de vencimento ou de pagamento", response.Error.ErrorMessage);
        }

        #endregion

        #region FetchBalance tests

        [TestMethod]
        public void FetchBalance()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            FetchBalanceResponse response = boletoFacil.FetchBalance();

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.IsInstanceOfType(response.Data, typeof(PayeeBalance));
            Assert.AreEqual(100m, response.Data.Balance);
            Assert.AreEqual(30m, response.Data.WithheldBalance);
            Assert.AreEqual(70m, response.Data.TransferableBalance);
        }

        #endregion

        #region CancelCharge tests

        [TestMethod]
        public void CancelCharge()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Charge charge = new Charge();
            charge.Code = "12345678";

            CancelChargeResponse response = boletoFacil.CancelCharge(charge);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void CancelChargeError()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Charge charge = Charge;
            charge.Code = "00000000";

            BoletoFacilRequestException response = AssertException<BoletoFacilRequestException>(() => boletoFacil.CancelCharge(charge));

            Assert.IsNotNull(response);
            Assert.AreEqual(400, response.HTTPStatusCode);
            Assert.IsFalse(response.Error.Success);
            Assert.AreEqual("Cobrança inválida", response.Error.ErrorMessage);
        }

        #endregion

        #region CreatePayee tests

        [TestMethod]
        public void CreatePayeeMandatoryFields()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Payee payee = Payee;

            PayeeResponse response = boletoFacil.CreatePayee(payee);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.IsInstanceOfType(response.Data, typeof(Payee));
            Assert.AreEqual("22FAC22222EE2D22222222ADDDDDBEF38B222222D22D22E2", response.Data.Token);
        }

        [TestMethod]
        public void CreatePayeeAutoApprovedAndEmailOptOut()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Payee payee = Payee;
            payee.EmailOptOut = true;
            payee.AutoApprove = true;

            PayeeResponse response = boletoFacil.CreatePayee(payee);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.IsInstanceOfType(response.Data, typeof(Payee));
            Assert.AreEqual("22FAC22222EE2D22222222ADDDDDBEF38B222222D22D22E2", response.Data.Token);
        }

        [TestMethod]
        public void CreatePayeeMethodNotAllowedException()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Payee payee = Payee;
            payee.CpfCnpj = "12345678000199";

            BoletoFacilRequestException response = AssertException<BoletoFacilRequestException>(() => boletoFacil.CreatePayee(payee));

            Assert.IsNotNull(response);
            Assert.AreEqual(405, response.HTTPStatusCode);
        }

        #endregion

        #region CreatePayeeFeeSchema tests

        [TestMethod]
        public void CreatePayeeFeeSchemaSplitFixed()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Split split = Split;
            split.SplitFixed = 5;

            FeeSchemaResponse response = boletoFacil.CreatePayeeFeeSchema(split);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.IsInstanceOfType(response.Data, typeof(FeeSchema));
            Assert.AreEqual(123, response.Data.Id);
            Assert.AreEqual("37515135CBD4FA0176F77F944C15F064CB714C75FE23685B9EC84693A05B10F783FDC05C31BF5800", response.Data.FeeSchemaToken);
        }

        [TestMethod]
        public void CreatePayeeFeeSchemaSplitVariable()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Split split = Split;
            split.SplitVariable = 25;

            FeeSchemaResponse response = boletoFacil.CreatePayeeFeeSchema(split);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.IsInstanceOfType(response.Data, typeof(FeeSchema));
            Assert.AreEqual(123, response.Data.Id);
            Assert.AreEqual("37515135CBD4FA0176F77F944C15F064CB714C75FE23685B9EC84693A05B10F783FDC05C31BF5800", response.Data.FeeSchemaToken);
        }

        #endregion

        #region GetPayeeStatus tests

        [TestMethod]
        public void GetPayeeStatus()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Payee payee = Payee;

            PayeeResponse response = boletoFacil.GetPayeeStatus(payee);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.IsInstanceOfType(response.Data, typeof(Payee));
            Assert.AreEqual("Aprovado", response.Data.Status);
        }

        [TestMethod]
        public void GetPayeeStatusInvalidPayeeException()
        {
            BoletoFacil boletoFacil = GetBoletoFacil();
            Payee payee = new Payee();
            payee.CpfCnpj = "12345678000199";

            BoletoFacilRequestException response = AssertException<BoletoFacilRequestException>(() => boletoFacil.GetPayeeStatus(payee));

            Assert.IsNotNull(response);
            Assert.AreEqual(400, response.HTTPStatusCode);
            Assert.IsFalse(response.Error.Success);
            Assert.AreEqual("Favorecido com CPF/CNPJ 12345678000199 inválido ou não encontrado", response.Error.ErrorMessage);
        }

        #endregion

        BoletoFacil GetBoletoFacil()
        {
            MockedResponseHandler responseHandler = new MockedResponseHandler();
            BoletoFacil boletoFacil = new BoletoFacil(BoletoFacilEnvironment.UnitTests, "XPTO");
            boletoFacil.MessageHandler = responseHandler;
            return boletoFacil;
        }

        void AssertError(BoletoFacilRequestException response, string errorMessage)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(400, response.HTTPStatusCode);
            Assert.IsFalse(response.Error.Success);
            Assert.AreEqual(errorMessage, response.Error.ErrorMessage);
        }
    }
}
