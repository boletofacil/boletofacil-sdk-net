using System;
using System.Globalization;
using Newtonsoft.Json;

namespace BoletoFacilSDK.Model
{
    public class DateTimeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                DateTime date = (DateTime)value;
                writer.WriteValue($"{date:dd/MM/yyyy}");
            }
            else
            {
                throw new Exception("Expected date object value.");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var dateString = (string)reader.Value;
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return date;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}