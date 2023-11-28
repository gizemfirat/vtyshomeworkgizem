using Newtonsoft.Json;
using Vtys.Core.Constants;

namespace Vtys.Core.ExtensionMethods
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }

        public static T FromJson<T>(this string json)
        {
            var result = JsonConvert.DeserializeObject<T>(json);

            if (result == null)
            {
                throw new Exception(Messages.WRONG_JSON_TYPE);
            }

            return result;
        }
    }
}
