using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using BoletoFacilSDK.Exceptions;
using Newtonsoft.Json.Serialization;

namespace BoletoFacilSDK.Model
{
    public class ModelBase
    {
        public string ToJson()
        {
            JsonSerializerSettings s = new JsonSerializerSettings();
            s.MissingMemberHandling = MissingMemberHandling.Ignore;
            s.NullValueHandling = NullValueHandling.Ignore;
            s.MissingMemberHandling = MissingMemberHandling.Ignore;
            s.TypeNameHandling = TypeNameHandling.Auto;
            s.ContractResolver = new CamelCasePropertyNamesContractResolver();

            try
            {
                //JsonConvert.SerializeObject(this, Formatting.Indented, s);
                return JsonConvert.SerializeObject(this, Formatting.Indented, s);
            }
            catch (Exception e)
            {
                throw new BoletoFacilInvalidEntityException(this, e);
            }
        }

        public static T FromJson<T>(string jsonObject)
        {
            return JsonConvert.DeserializeObject<T>(jsonObject);
        }

        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(GetType());
            using (StringWriter writer = new StringWriter(new StringBuilder()))
            {
                serializer.Serialize(writer, this);
                return writer.ToString();
            }
        }

        public static T FromXml<T>(string xmlObject)
        {
            XDocument doc = XDocument.Parse(xmlObject);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var reader = doc.CreateReader())
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}