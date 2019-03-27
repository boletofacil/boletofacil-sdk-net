using System;
using System.Net;

namespace BoletoFacilSDK
{
    public class Proxy : IWebProxy
    {
        public ICredentials Credentials { get; set; }

        private readonly Uri _proxyUri;

        public Proxy(Uri proxyUri)
        {
            _proxyUri = proxyUri;
        }

        public Proxy(Uri proxyUri, ICredentials credentials)
        {
            _proxyUri = proxyUri;
            Credentials = credentials;
        }

        public Proxy(string proxyUri, ICredentials credentials)
        {
            _proxyUri = new Uri(proxyUri);
            Credentials = credentials;
        }

        public Uri GetProxy(Uri destination)
        {
            return _proxyUri;
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
