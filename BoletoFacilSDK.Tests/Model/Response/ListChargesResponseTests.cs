using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Tests.Model.Response
{
    [TestClass]
    public class ListChargesResponseTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            ListChargesResponse obj = new ListChargesResponse();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Data);

            obj.Data = new ChargeList();
            obj.Data.Charges = new Charge[1];
            obj.Data.Charges[0] = new Charge();
            Assert.IsNotNull(obj.Data);
            Assert.IsNotNull(obj.ToJson());
        }
    }
}
