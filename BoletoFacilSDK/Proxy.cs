using System;
using System.Net;

namespace BoletoFacilSDK
{
#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy"
    public class Proxy : IWebProxy
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy"
    {
#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.Credentials"
        public ICredentials Credentials { get; set; }
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.Credentials"

        private readonly Uri _proxyUri;

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.Proxy(Uri)"
        public Proxy(Uri proxyUri)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.Proxy(Uri)"
        {
            _proxyUri = proxyUri;
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.Proxy(Uri, ICredentials)"
        public Proxy(Uri proxyUri, ICredentials credentials)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.Proxy(Uri, ICredentials)"
        {
            _proxyUri = proxyUri;
            Credentials = credentials;
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.Proxy(string, ICredentials)"
        public Proxy(string proxyUri, ICredentials credentials)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.Proxy(string, ICredentials)"
        {
            _proxyUri = new Uri(proxyUri);
            Credentials = credentials;
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.GetProxy(Uri)"
        public Uri GetProxy(Uri destination)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.GetProxy(Uri)"
        {
            return _proxyUri;
        }

#pragma warning disable CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.IsBypassed(Uri)"
        public bool IsBypassed(Uri host)
#pragma warning restore CS1591 // Comentário XML ausente para tipo publicamente visível ou membro "Proxy.IsBypassed(Uri)"
        {
            return false;
        }
    }
}
