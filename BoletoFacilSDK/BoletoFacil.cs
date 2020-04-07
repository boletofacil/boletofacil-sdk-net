using System;
using System.Text;
using BoletoFacilSDK.Enums;
using BoletoFacilSDK.Exceptions;
using BoletoFacilSDK.Model;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Request;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK
{
    /// <summary>
    /// BoletoFacil is an HTTP Client for connecting to Boleto Facil's API.
    /// </summary>
    public class BoletoFacil : BoletoFacilBase
    {
        const string VERSION = "1.0.0";

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.BoletoFacil(BoletoFacilEnvironment, string)"
        public BoletoFacil(BoletoFacilEnvironment boletoFacilEnvironment, string token)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.BoletoFacil(BoletoFacilEnvironment, string)"
            : base (VERSION)
        {

            //if (String.IsNullOrEmpty(publicToken))
            //{
            //    throw new BoletoFacilTokenException("Token Público do favorecido inválido");
            //}
            //PublicToken = publicToken;

            if (String.IsNullOrEmpty(token))
            {
                throw new BoletoFacilTokenException("Token do favorecido inválido");
            }
            Token = token;
            BoletoFacilEnvironment = boletoFacilEnvironment;
        }

        #region API request methods

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.IssueCharge(Charge, ResponseType)"
        public ChargeResponse IssueCharge(Charge charge, ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.IssueCharge(Charge, ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/issue-charge?");
            AddRequestParameters(requestUri, RequestType.IssueCharge, charge);
            return Request<ChargeResponse>(requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.RequestTransfer(Transfer, ResponseType)"
        public TransferResponse RequestTransfer(Transfer transfer, ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.RequestTransfer(Transfer, ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/request-transfer?");
            AddRequestParameters(requestUri, RequestType.RequestTransfer, transfer);
            return Request<TransferResponse>(requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.ListCharges(ListChargesDates, ResponseType)"
        public ListChargesResponse ListCharges(ListChargesDates dates, ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.ListCharges(ListChargesDates, ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/list-charges?");
            AddRequestParameters(requestUri, RequestType.ListCharges, dates);
            return Request<ListChargesResponse>(requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.FetchBalance(ResponseType)"
        public FetchBalanceResponse FetchBalance(ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.FetchBalance(ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/fetch-balance?");
            AddRequestParameters(requestUri, RequestType.FetchBalance, null);
            return Request<FetchBalanceResponse>(requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.CancelCharge(Charge, ResponseType)"
        public CancelChargeResponse CancelCharge(Charge charge, ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.CancelCharge(Charge, ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/cancel-charge?");
            AddRequestParameters(requestUri, RequestType.CancelCharge, charge);
            return Request<CancelChargeResponse>(requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.CreatePayee(Payee, ResponseType)"
        public PayeeResponse CreatePayee(Payee payee, ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.CreatePayee(Payee, ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/create-payee?");
            AddRequestParameters(requestUri, RequestType.CreatePayee, payee);
            return PostRequest<PayeeResponse>(requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.CreatePayeeFeeSchema(Split, ResponseType)"
        public FeeSchemaResponse CreatePayeeFeeSchema(Split split, ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.CreatePayeeFeeSchema(Split, ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/create-payee-fee-schema?");
            AddRequestParameters(requestUri, RequestType.CreatePayeeFeeSchema, split);
            return Request<FeeSchemaResponse>(requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.GetPayeeStatus(Payee, ResponseType)"
        public PayeeResponse GetPayeeStatus(Payee payee, ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.GetPayeeStatus(Payee, ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/get-payee-status?");
            AddRequestParameters(requestUri, RequestType.GetPayeeStatus, payee);
            return Request<PayeeResponse>(requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.CardTokenization(Charge, ResponseType)"
        public TokenizationResponse CardTokenization(Charge creditCardHash, ResponseType responseType = ResponseType.JSON)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacil.CardTokenization(Charge, ResponseType)"
        {
            StringBuilder requestUri = new StringBuilder($"{EndPoint}/card-tokenization?");
            AddRequestParameters(requestUri, RequestType.CardTokenization, creditCardHash);
            return PostRequest<TokenizationResponse>(requestUri, responseType);
        }
        //public PublicKeyResponse GetPublicEncryptionKey(ResponseType responseType = ResponseType.JSON)
        //{
        //    StringBuilder requestUri = new StringBuilder($"{EndPoint}/get-public-encryption-key.json?");
        //    AddRequestParameters(requestUri, RequestType.GetPublicEncryptionKey, null);
        //    return Request<PublicKeyResponse>(requestUri, responseType);
        //}

        //public CardHashResponse GetCreditCardHash(ResponseType responseType = ResponseType.JSON)
        //{
        //    StringBuilder requestUri = new StringBuilder($"{EndPoint}/get-credit-card-hash.json?");
        //    AddRequestParameters(requestUri, RequestType.GetCreditCardHash, null);
        //    return Request<CardHashResponse>(requestUri, responseType);
        //}

        #endregion

        #region AddRequestParameters methods

        void AddRequestParameters(StringBuilder requestUri, RequestType requestType, ModelBase entity)
        {
            AddTokenUriParameter(requestUri);
            switch (requestType)
            {
                case RequestType.IssueCharge:
                    Charge chargeToIssue = entity as Charge;
                    AddIssueChargeParameters(requestUri, chargeToIssue);
                    break;
                case RequestType.RequestTransfer:
                    Transfer transfer = entity as Transfer;
                    AddRequestTransferParameters(requestUri, transfer);
                    break;
                case RequestType.ListCharges:
                    ListChargesDates dates = entity as ListChargesDates;
                    AddListChargeParameters(requestUri, dates);
                    break;
                case RequestType.FetchBalance:
                    break;
                case RequestType.CancelCharge:
                    Charge chargeToCancel = entity as Charge;
                    AddCancelChargeParameters(requestUri, chargeToCancel);
                    break;
                case RequestType.CreatePayee:
                    Payee payeeToCreate = entity as Payee;
                    AddCreatePayeeParameters(requestUri, payeeToCreate);
                    break;
                case RequestType.CreatePayeeFeeSchema:
                    Split split = entity as Split;
                    AddCreatePayeeFeeSchemaParameters(requestUri, split);
                    break;
                case RequestType.GetPayeeStatus:
                    Payee payeeToGetStatus = entity as Payee;
                    AddGetPayeeStatusParameters(requestUri, payeeToGetStatus);
                    break;
                case RequestType.CardTokenization:
                    Charge creditCardHash = entity as Charge;
                    AddCardTokenizationParameters(requestUri, creditCardHash);
                    break;
            }
            //AddPublicTokenUriParameter(requestUri);
            //switch (requestType)
            //{
                
            //}
        }

        void AddIssueChargeParameters(StringBuilder requestUri, Charge charge)
        {
            AddUriParameter(requestUri, "description", charge.Description);
            AddUriParameter(requestUri, "reference", charge.Reference);
            AddUriParameter(requestUri, "amount", $"{charge.Amount:F2}");
            AddUriParameter(requestUri, "totalAmount", $"{charge.TotalAmount:F2}");
            AddUriParameter(requestUri, "dueDate", charge.DueDate > DateTime.MinValue ? $"{charge.DueDate:dd/MM/yyyy}" : String.Empty);
            AddUriParameter(requestUri, "installments", $"{charge.Installments}");
            AddUriParameter(requestUri, "maxOverdueDays", $"{charge.MaxOverdueDays}");
            AddUriParameter(requestUri, "fine", $"{charge.Fine:F2}");
            AddUriParameter(requestUri, "interest", $"{charge.Interest:F2}");
            AddUriParameter(requestUri, "discountAmount", $"{charge.Discount?.Amount:F2}");
            AddUriParameter(requestUri, "discountDays", $"{charge.Discount?.Days}");
            AddUriParameter(requestUri, "payerName", charge.Payer?.Name);
            AddUriParameter(requestUri, "payerCpfCnpj", charge.Payer?.CpfCnpj);
            AddUriParameter(requestUri, "payerEmail", charge.Payer?.Email);
            AddUriParameter(requestUri, "payerSecondaryEmail", charge.Payer?.SecondaryEmail);
            AddUriParameter(requestUri, "payerPhone", charge.Payer?.Phone);
            AddUriParameter(requestUri, "payerBirthDate", $"{charge.Payer?.BirthDate:dd/MM/yyyy}");
            AddUriParameter(requestUri, "billingAddressStreet", charge.BillingAddress?.Street);
            AddUriParameter(requestUri, "billingAddressNumber", charge.BillingAddress?.Number);
            AddUriParameter(requestUri, "billingAddressComplement", charge.BillingAddress?.Complement);
            AddUriParameter(requestUri, "billingAddressNeighborhood", charge.BillingAddress?.Neighborhood);
            AddUriParameter(requestUri, "billingAddressCity", charge.BillingAddress?.City);
            AddUriParameter(requestUri, "billingAddressState", charge.BillingAddress?.State);
            AddUriParameter(requestUri, "billingAddressPostcode", charge.BillingAddress?.Postcode);
            AddUriParameter(requestUri, "notifyPayer", $"{charge.NotifyPayer}");
            AddUriParameter(requestUri, "notificationUrl", $"{charge.NotificationUrl}");
            AddUriParameter(requestUri, "feeSchemaToken", $"{charge.FeeSchemaToken}");
            AddUriParameter(requestUri, "splitRecipient", $"{charge.SplitRecipient}");
            AddUriParameter(requestUri, "referralToken", charge.ReferralToken);
            AddUriParameter(requestUri, "paymentTypes", charge.PaymentTypes == null ? null : string.Join(",", charge.PaymentTypes));
            AddUriParameter(requestUri, "creditCardHash", $"{charge.CreditCardHash}");
            AddUriParameter(requestUri, "creditCardId", $"{charge.CreditCardId}");
            AddUriParameter(requestUri, "paymentAdvance", $"{charge.PaymentAdvance}");
        }

        void AddRequestTransferParameters(StringBuilder requestUri, Transfer transfer)
        {
            AddUriParameter(requestUri, "amount", $"{transfer.Amount:F2}");
        }

        void AddCancelChargeParameters(StringBuilder requestUri, Charge charge)
        {
            AddUriParameter(requestUri, "code", charge.Code);
        }

        void AddListChargeParameters(StringBuilder requestUri, ListChargesDates dates)
        {
            AddUriParameter(requestUri, "beginDueDate", $"{dates.BeginDueDate:dd/MM/yyyy}");
            AddUriParameter(requestUri, "endDueDate", $"{dates.EndDueDate:dd/MM/yyyy}");
            AddUriParameter(requestUri, "beginPaymentDate", $"{dates.BeginPaymentDate:dd/MM/yyyy}");
            AddUriParameter(requestUri, "endPaymentDate", $"{dates.EndPaymentDate:dd/MM/yyyy}");
			AddUriParameter(requestUri, "beginPaymentConfirmation", $"{dates.BeginPaymentConfirmation:dd/MM/yyyy}");
			AddUriParameter(requestUri, "endPaymentConfirmation", $"{dates.EndPaymentConfirmation:dd/MM/yyyy}");
        }

        void AddCreatePayeeParameters(StringBuilder requestUri, Payee payee)
        {
            AddUriParameter(requestUri, "notificationUrl", payee.NotificationUrl);
            AddUriParameter(requestUri, "name", payee.Name);
            AddUriParameter(requestUri, "cpfCnpj", payee.CpfCnpj);
            AddUriParameter(requestUri, "email", payee.Email);
            AddUriParameter(requestUri, "password", payee.Password);
            AddUriParameter(requestUri, "birthDate", $"{payee.BirthDate:dd/MM/yyyy}");
            AddUriParameter(requestUri, "phone", payee.Phone);
            AddUriParameter(requestUri, "linesOfBusiness", payee.LinesOfBusiness);
            AddUriParameter(requestUri, "tradingName", payee.TradingName);
            AddUriParameter(requestUri, "reprName", payee.Repr?.Name);
            AddUriParameter(requestUri, "reprCpfCnpj", payee.Repr?.CpfCnpj);
            AddUriParameter(requestUri, "reprBirthDate", $"{payee.Repr?.BirthDate:dd/MM/yyyy}");
            AddUriParameter(requestUri, "accountHolderName", payee.AccountHolder.Name);
            AddUriParameter(requestUri, "accountHolderCpfCnpj", payee.AccountHolder.CpfCnpj);
            AddUriParameter(requestUri, "bankNumber", payee.BankAccount.BankNumber);
            AddUriParameter(requestUri, "agencyNumber", payee.BankAccount.AgencyNumber);
            AddUriParameter(requestUri, "accountNumber", payee.BankAccount.AccountNumber);
            AddUriParameter(requestUri, "bankAccountType", $"{payee.BankAccount.BankAccountType}");
            AddUriParameter(requestUri, "accountComplementNumber", $"{payee.BankAccount.AccountComplementNumber}");
            AddUriParameter(requestUri, "category", $"{payee.Category}");
            AddUriParameter(requestUri, "companyType", $"{payee.CompanyType}");
            AddUriParameter(requestUri, "street", payee.Address.Street);
            AddUriParameter(requestUri, "number", payee.Address.Number);
            AddUriParameter(requestUri, "complement", payee.Address.Complement);
            AddUriParameter(requestUri, "neighborhood", payee.Address.Neighborhood);
            AddUriParameter(requestUri, "city", payee.Address.City);
            AddUriParameter(requestUri, "state", payee.Address.State);
            AddUriParameter(requestUri, "postCode", payee.Address.Postcode);
            AddUriParameter(requestUri, "businessAreaId", $"{payee.BusinessAreaId}");
            if (payee.EmailOptOut.HasValue)
            {
                AddUriParameter(requestUri, "emailOptOut", $"{payee.EmailOptOut}");
            }
            if (payee.AutoApprove.HasValue)
            {
                AddUriParameter(requestUri, "autoApprove", $"{payee.AutoApprove}");
            }
        }

        void AddGetPayeeStatusParameters(StringBuilder requestUri, Payee payee)
        {
            AddUriParameter(requestUri, "payeeCpfCnpj", payee.CpfCnpj);
        }

        void AddCreatePayeeFeeSchemaParameters(StringBuilder requestUri, Split split)
        {
            AddUriParameter(requestUri, "splitFixed", $"{split.SplitFixed:F2}");
            AddUriParameter(requestUri, "splitVariable", $"{split.SplitVariable:F2}");
            AddUriParameter(requestUri, "splitTriggerAmount", $"{split.SplitTriggerAmount:F2}");
        }

        void AddCardTokenizationParameters(StringBuilder requestUri, Charge creditCardHash)
        {
            AddUriParameter(requestUri, "creditCardHash", $"{creditCardHash.CreditCardHash}");
        }

        #endregion
    }
}
