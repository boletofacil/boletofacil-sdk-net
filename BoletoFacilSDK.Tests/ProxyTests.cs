using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoletoFacilSDK.Tests
{
    [TestClass]
    public class ProxyTests : AbstractTests
    {
        [TestMethod]
        public void Constructor1()
        {
            Uri uri = new Uri("http://localhost");

            Proxy proxy = new Proxy(uri);

            Assert.IsNotNull(proxy);
            Assert.AreEqual(uri, proxy.GetProxy(new Uri("http://externalhost")));
            Assert.IsNull(proxy.Credentials);
            Assert.IsFalse(proxy.IsBypassed(new Uri("http://externalhost")));
        }

        [TestMethod]
        public void Constructor2()
        {
            Uri uri = new Uri("http://localhost");
            ICredentials credentials = new CredentialCache();

            Proxy proxy = new Proxy(uri, credentials);

            Assert.IsNotNull(proxy);
            Assert.AreEqual(uri, proxy.GetProxy(new Uri("http://externalhost")));
            Assert.AreEqual(credentials, proxy.Credentials);
            Assert.IsFalse(proxy.IsBypassed(new Uri("http://externalhost")));
        }

        [TestMethod]
        public void Constructor3()
        {
            ICredentials credentials = new CredentialCache();

            Proxy proxy = new Proxy("http://localhost", credentials);

            Assert.IsNotNull(proxy);
            Assert.AreEqual(new Uri("http://localhost"), proxy.GetProxy(new Uri("http://externalhost")));
            Assert.AreEqual(credentials, proxy.Credentials);
            Assert.IsFalse(proxy.IsBypassed(new Uri("http://externalhost")));
        }
    }
}
