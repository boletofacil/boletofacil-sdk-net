using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Globalization;
using BoletoFacilSDK.Enums;
using BoletoFacilSDK.Exceptions;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK
{
    /// <summary>
    /// Base class for main SDK class (<see cref="BoletoFacil"/>), which 
    /// contains utility and common methods used throughout all API request methods.
    /// </summary>
    public class BoletoFacilBase
    {
        readonly string version;

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.BoletoFacilBase(string)"
        protected BoletoFacilBase(string version)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.BoletoFacilBase(string)"
        {
            this.version = version;
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.ProxyAddress"
        public string ProxyAddress { get; private set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.ProxyAddress"
#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.ProxyUsername"
        public string ProxyUsername { get; private set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.ProxyUsername"
#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.ProxyPassword"
        public string ProxyPassword { get; private set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.ProxyPassword"

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.Token"
        public string Token { get; protected set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.Token"
#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.PublicToken"
        public string PublicToken { get; protected set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.PublicToken"
#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.BoletoFacilEnvironment"
        public BoletoFacilEnvironment BoletoFacilEnvironment { get ; protected set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.BoletoFacilEnvironment"
       
#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.UseProxy"
        public bool UseProxy { get; private set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.UseProxy"
#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.MessageHandler"
        public HttpMessageHandler MessageHandler { private get; set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.MessageHandler"

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.EndPoint"
        protected Uri EndPoint => BoletoFacilEnvironment.Equals(BoletoFacilEnvironment.Production)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.EndPoint"
            ? new Uri("https://www.boletobancario.com/boletofacil/integration/api/v1")
            : BoletoFacilEnvironment.Equals(BoletoFacilEnvironment.Sandbox)
                ? new Uri("https://sandbox.boletobancario.com/boletofacil/integration/api/v1")
                : new Uri("https://sdktests.com/api");

        /// <summary>
        /// Set proxy address, send only the address with http://ip, even for https connections
        /// </summary>
        /// <param name="proxyAddress">Proxy address, even for https connections, use http</param>
        /// <param name="proxyUser"></param>
        /// <param name="proxyPassword"></param>
        public void SetProxy(string proxyAddress, string proxyUser, string proxyPassword)
        {
            ProxyUsername = proxyUser;
            ProxyPassword = proxyPassword;
            ProxyAddress = proxyAddress;
            UseProxy = true;
        }

        HttpClient CreateHttpClient()
        {
            HttpClient httpClient;

            if (!UseProxy)
            {
                httpClient = MessageHandler == null ? new HttpClient() : new HttpClient(MessageHandler);
            }
            else
            {
                var httpClientHandler = new HttpClientHandler
                {
                    UseDefaultCredentials = false,
                    Proxy = new Proxy(ProxyAddress, new NetworkCredential(ProxyUsername, ProxyPassword)),
                    UseProxy = true
                };

                httpClient = MessageHandler == null ? new HttpClient(httpClientHandler) : new HttpClient(MessageHandler);
            }

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("X-Requested-With", "Boleto Facil SDK .NET " + version);
            httpClient.BaseAddress = EndPoint;

            return httpClient;
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.Request<T>(StringBuilder, ResponseType)"
        protected T Request<T>(StringBuilder requestUri, ResponseType responseType) where T : BaseResponse
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.Request<T>(StringBuilder, ResponseType)"
        {
            return Request<T>(HttpMethod.Get, requestUri, responseType);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.PostRequest<T>(StringBuilder, ResponseType)"
        protected T PostRequest<T>(StringBuilder requestUri, ResponseType responseType) where T : BaseResponse
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.PostRequest<T>(StringBuilder, ResponseType)"
        {
            return Request<T>(HttpMethod.Post, requestUri, responseType);
        }

        T Request<T>(HttpMethod method, StringBuilder requestUri, ResponseType responseType) where T : BaseResponse 
        {
            AddUriParameter(requestUri, "responseType", responseType.ToString());
            HttpContent content = new StringContent("");

            var client = CreateHttpClient();

            var httpResponse = method == HttpMethod.Get
                ? client.GetAsync(requestUri.ToString()).Result
                : client.PostAsync(requestUri.ToString(), content).Result;
            var responseContent = httpResponse.Content;
            string responseBody = responseContent.ReadAsStringAsync().Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                return GetResponse<T>(responseType, responseBody);
            }
            if (httpResponse.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                throw new BoletoFacilMethodNotAllowedException(
                    $"A chamada {GetAPIActionName(requestUri)} não suporta o método {method}. " +
                    "Verifique se existe alguma atualização do SDK ou entre em contato com a equipe do Boleto Fácil.");
            }
            ErrorResponse error = GetResponse<ErrorResponse>(responseType, responseBody);
            throw new BoletoFacilRequestException((int)httpResponse.StatusCode, error);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.AddTokenUriParameter(StringBuilder)"
        protected void AddTokenUriParameter(StringBuilder requestUri)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.AddTokenUriParameter(StringBuilder)"
        {
            AddUriParameter(requestUri, "token", Token);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.AddPublicTokenUriParameter(StringBuilder)"
        protected void AddPublicTokenUriParameter(StringBuilder requestUri)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.AddPublicTokenUriParameter(StringBuilder)"
        {
            AddUriParameter(requestUri, "publicToken", PublicToken);
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.AddUriParameter(StringBuilder, string, string)"
        protected void AddUriParameter(StringBuilder requestUri, string parameter, string value) 
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "BoletoFacilBase.AddUriParameter(StringBuilder, string, string)"
        {
            string separator = requestUri[requestUri.Length - 1] == '?' ? "": "&";
            requestUri.Append($"{separator}{parameter}={value}");
        }

        T GetResponse<T>(ResponseType responseType, string responseBody)
        {
            return responseType == ResponseType.JSON ? Model.ModelBase.FromJson<T>(responseBody) : Model.ModelBase.FromXml<T>(responseBody);
        }

        string GetAPIActionName(StringBuilder requestUri)
        {
            string request = requestUri.ToString();
            int questionMark = request.IndexOf("?", StringComparison.Ordinal);
            string requestEndPoint = request.Substring(0, questionMark);

            int lastSlash = requestEndPoint.LastIndexOf("/", StringComparison.Ordinal);
            return requestEndPoint.Substring(lastSlash + 1);
        }
    }
}