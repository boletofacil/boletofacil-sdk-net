using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoletoFacilSDK.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace BoletoFacilSDK.Tests.Model
{
    [TestClass]
    public class DateTimeJsonConverterTests : AbstractTests
    {
        [TestMethod]
        public void ReadJson()
        {
            string date = "\"20/10/2017\"";
            JsonReader reader = new JsonTextReader(new StringReader(date));
            while (reader.Read())
            {
                if (date.Substring(1, date.Length - 2).Equals(reader.Value))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    DateTimeJsonConverter converter = new DateTimeJsonConverter();

                    object result = converter.ReadJson(reader, typeof(DateTime), new DateTime(2017, 10, 20), serializer);

                    Assert.IsNotNull(result);
                    Assert.IsInstanceOfType(result, typeof(DateTime));
                }
            }
        }

        [TestMethod]
        public void WriteJson()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                DateTimeJsonConverter converter = new DateTimeJsonConverter();
                converter.WriteJson(writer, DateTime.Today, null);
                Assert.IsNotNull(converter);
            }
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void WriteJsonException()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                DateTimeJsonConverter converter = new DateTimeJsonConverter();
                converter.WriteJson(writer, "", null);
            }
        }

        [TestMethod]
        public void CanConvert()
        {
            string date = "\"20/10/2017\"";
            JsonReader reader = new JsonTextReader(new StringReader(date));
            while (reader.Read())
            {
                if (date.Substring(1, date.Length - 2).Equals(reader.Value))
                {
                    DateTimeJsonConverter converter = new DateTimeJsonConverter();
                    Assert.IsTrue(converter.CanConvert(date.GetType()));
                }
            }
        }
    }
}
