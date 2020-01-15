using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }

    public class DateTimeNullableConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return string.IsNullOrEmpty(reader.GetString()) ? default(DateTime?) : DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString("yyyy-MM-dd"));
        }
    }

    //public class ObjectToInferredTypesConverter : JsonConverter<DbListResult<object>>
    //{
    //    public override DbListResult<object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        if (reader.HasValueSequence)
    //        {

    //        }

    //        if (reader.TokenType == JsonTokenType.String)
    //        {
    //            if (reader.TryGetDateTime(out DateTime datetime))
    //            {
    //                return datetime;
    //            }

    //            return reader.GetString();
    //        }

    //        // Use JsonElement as fallback.
    //        // Newtonsoft uses JArray or JObject.
    //        using JsonDocument document = JsonDocument.ParseValue(ref reader);
    //        return document.RootElement.Clone();
    //    }

    //    public override void Write(Utf8JsonWriter writer, DbListResult<object> value, JsonSerializerOptions options)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}