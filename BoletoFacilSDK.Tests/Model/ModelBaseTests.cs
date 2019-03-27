using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model;
using BoletoFacilSDK.Model.Response;

namespace BoletoFacilSDK.Tests.Model
{
    [TestClass]
    public class ModelBaseTests : AbstractTests
    {
        [TestMethod]
        public void FromJson()
        {
            string json = "{\"success\":false,\"errorMessage\":\"Parâmetro obrigatório 'amount' não está presente\"}";
            ErrorResponse error = ModelBase.FromJson<ErrorResponse>(json);
            Assert.AreEqual("Parâmetro obrigatório 'amount' não está presente", error.ErrorMessage);
        }

        [TestMethod]
        public void ToJson()
        {
            DummyModelClass testClass = new DummyModelClass();
            AssertResult("{\"id\": 0}", testClass.ToJson());

            testClass.Id = 1;
            testClass.Name = "João da Silva";
            AssertResult("{\"id\": 1, \"name\": \"João da Silva\"}", testClass.ToJson());
        }

        [TestMethod]
        public void FromXml()
        {
            string xml = "<result><success>false</success><errorMessage>Valor mínimo para cobrança é de R$ 2,30</errorMessage></result>";
            ErrorResponse error = ModelBase.FromXml<ErrorResponse>(xml);
            Assert.AreEqual("Valor mínimo para cobrança é de R$ 2,30", error.ErrorMessage);
        }

        [TestMethod]
        public void ToXml()
        {
            DummyModelClass testClass = new DummyModelClass();
            AssertResult("<?xmlversion=\"1.0\"encoding=\"utf-16\"?>" +
                         "<DummyModelClassxmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                         "<Id>0</Id>" +
                         "</DummyModelClass>", testClass.ToXml());

            testClass.Id = 1;
            testClass.Name = "João da Silva";
            AssertResult("<?xmlversion=\"1.0\"encoding=\"utf-16\"?>" +
                         "<DummyModelClassxmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                         "<Id>1</Id>" +
                         "<Name>JoãodaSilva</Name>" +
                         "</DummyModelClass>", testClass.ToXml());
        }
    }

    public class DummyModelClass : ModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
