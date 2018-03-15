using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model.Entities;

namespace BoletoFacilSDK.Tests.Model.Entities
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void ConstructorAndFields()
        {
            Person obj = new Person();

            Assert.IsNotNull(obj);
            Assert.IsNull(obj.Name);
            Assert.IsNull(obj.CpfCnpj);
            Assert.IsNull(obj.BirthDate);
            Assert.IsNull(obj.BirthDateString);

            obj.Name = "Nome da pessoa";
            obj.CpfCnpj = "11.222.333/0001-99";
            obj.BirthDate = DateTime.Today;
            obj.BirthDateString = $"{DateTime.Today:dd/MM/yyyy}";
            Assert.AreEqual("Nome da pessoa", obj.Name);
            Assert.AreEqual("11.222.333/0001-99", obj.CpfCnpj);
            Assert.AreEqual(DateTime.Today, obj.BirthDate);
            Assert.AreEqual($"{DateTime.Today:dd/MM/yyyy}", obj.BirthDateString);
        }
    }
}
