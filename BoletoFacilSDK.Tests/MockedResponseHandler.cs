using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace BoletoFacilSDK.Tests
{
    public class MockedResponseHandler : DelegatingHandler
    {
        public static string TESTS_URL = "https://sdktests.com/api";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                bool error;
                if (request.RequestUri.AbsoluteUri.Contains("issue-charge?"))
                {
                    StringContent messageContent = new StringContent(CreateChargeResponse(request.RequestUri, out error));
                    var message = new HttpResponseMessage(error ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
                    message.Content = messageContent;
                    return message;
                }
                else if (request.RequestUri.AbsoluteUri.Contains("request-transfer?"))
                {
                    StringContent messageContent = new StringContent(CreateTransferResponse());
                    var message = new HttpResponseMessage(HttpStatusCode.OK);
                    message.Content = messageContent;
                    return message;
                }
                else if (request.RequestUri.AbsoluteUri.Contains("list-charges?"))
                {
                    StringContent messageContent = new StringContent(CreateListChargesResponse(request.RequestUri, out error));
                    var message = new HttpResponseMessage(error ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
                    message.Content = messageContent;
                    return message;
                }
                else if (request.RequestUri.AbsoluteUri.Contains("fetch-balance?"))
                {
                    StringContent messageContent = new StringContent(CreateBalanceResponse());
                    var message = new HttpResponseMessage(HttpStatusCode.OK);
                    message.Content = messageContent;
                    return message;
                }
                else if (request.RequestUri.AbsoluteUri.Contains("cancel-charge?"))
                {
                    StringContent messageContent = new StringContent(CreateCancelChargeResponse(request.RequestUri, out error));
                    var message = new HttpResponseMessage(error ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
                    message.Content = messageContent;
                    return message;
                }
                else if (request.RequestUri.AbsoluteUri.Contains("create-payee?"))
                {
                    StringContent messageContent = new StringContent(CreatePayeeResponse(request.RequestUri, out error));
                    var message = new HttpResponseMessage(error ? HttpStatusCode.MethodNotAllowed : HttpStatusCode.OK);
                    message.Content = messageContent;
                    return message;
                }
                else if (request.RequestUri.AbsoluteUri.Contains("create-payee-fee-schema?"))
                {
                    StringContent messageContent = new StringContent(CreatePayeeFeeSchemaResponse());
                    var message = new HttpResponseMessage(HttpStatusCode.OK);
                    message.Content = messageContent;
                    return message;
                }
                else if (request.RequestUri.AbsoluteUri.Contains("get-payee-status?"))
                {
                    StringContent messageContent = new StringContent(GetPayeeStatusResponse(request.RequestUri, out error));
                    var message = new HttpResponseMessage(error ? HttpStatusCode.BadRequest : HttpStatusCode.OK);
                    message.Content = messageContent;
                    return message;
                }

                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    RequestMessage = request
                };
            }, cancellationToken);
        }

        #region Create mocked response methods

        string CreateChargeResponse(Uri requestUri, out bool error)
        {
            string amount = GetQueryStringParameter(requestUri, "amount");
            string payerName = GetQueryStringParameter(requestUri, "payerName");
            string installments = GetQueryStringParameter(requestUri, "installments");

            TextReader tr;
            error = true;
            if (String.IsNullOrEmpty(amount) || decimal.Parse(amount) == 0)
            {
                tr = GetInputFile("IssueChargeErrorInvalidAmount.txt");
            }
            else if (String.IsNullOrEmpty(payerName))
            {
                tr = GetInputFile("IssueChargeErrorNullPayer.txt");
            }
            else
            {
                error = false;
                tr = !String.IsNullOrEmpty(installments) && !"1".Equals(installments)
                    ? GetInputFile("IssueChargeCarnet.txt")
                    : GetInputFile("IssueChargeUnique.txt");
            }

            return tr.ReadToEnd();
        }

        string CreateTransferResponse()
        {
            TextReader tr = GetInputFile("RequestTransfer.txt");
            return tr.ReadToEnd();
        }

        string CreateListChargesResponse(Uri requestUri, out bool error)
        {
            string beginDueDate = GetQueryStringParameter(requestUri, "beginDueDate");
            string beginPaymentDate = GetQueryStringParameter(requestUri, "beginPaymentDate");

            TextReader tr;
            error = true;
            if (!String.IsNullOrEmpty(beginDueDate) || !String.IsNullOrEmpty(beginPaymentDate))
            {
                error = false;
                tr = GetInputFile("ListCharges.txt");
            }
            else
            {
                tr = GetInputFile("ListChargesError.txt");
            }

            return tr.ReadToEnd();
        }

        string CreateBalanceResponse()
        {
            TextReader tr = GetInputFile("FetchBalance.txt");
            return tr.ReadToEnd();
        }

        string CreateCancelChargeResponse(Uri requestUri, out bool error)
        {
            string chargeCode = GetQueryStringParameter(requestUri, "code");

            TextReader tr;
            error = true;
            if ("00000000".Equals(chargeCode))
            {
                tr = GetInputFile("CancelChargeError.txt");
            }
            else
            {
                error = false;
                tr = GetInputFile("CancelCharge.txt");
            }

            return tr.ReadToEnd();
        }

        string CreatePayeeResponse(Uri requestUri, out bool error)
        {
            string cpfCnpj = GetQueryStringParameter(requestUri, "cpfCnpj");

            TextReader tr = GetInputFile("CreatePayee.txt");
            error = "12345678000199".Equals(cpfCnpj);
            return tr.ReadToEnd();
        }

        string CreatePayeeFeeSchemaResponse()
        {
            TextReader tr = GetInputFile("FeeSchema.txt");
            return tr.ReadToEnd();
        }

        string GetPayeeStatusResponse(Uri requestUri, out bool error)
        {
            string cpfCnpj = GetQueryStringParameter(requestUri, "payeeCpfCnpj");

            TextReader tr;
            error = true;
            if ("12345678000199".Equals(cpfCnpj))
            {
                tr = GetInputFile("PayeeStatusError.txt");
            }
            else
            {
                error = false;
                tr = GetInputFile("PayeeStatus.txt");
            }
            return tr.ReadToEnd();
        }

        #endregion

        #region Other private helper methods

        string GetQueryStringParameter(Uri requestUri, string parameterName)
        {
            string queryString = requestUri.Query;
            var queryDictionary = HttpUtility.ParseQueryString(queryString);
            var keys = queryDictionary.Keys;
            return queryDictionary[parameterName];
        }

        TextReader GetInputFile(string filename)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            string path = "BoletoFacilSDK.Tests.Resources";
            return new StreamReader(thisAssembly.GetManifestResourceStream(path + "." + filename));
        }

        #endregion
    }
}
