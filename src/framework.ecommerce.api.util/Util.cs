using Newtonsoft.Json;
using System;

namespace framework.ecommerce.api.util
{
    public static class Util
    {
        public static T GetValue<T>(object value)
        {
            if (value == null || DBNull.Value.Equals(value))
                return default(T);

            var t = typeof(T);
            return (T)Convert.ChangeType(value, Nullable.GetUnderlyingType(t) ?? t);
        }

        public static T DeserializarObjectParaJson<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        public static string SerializarObjectParaJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
