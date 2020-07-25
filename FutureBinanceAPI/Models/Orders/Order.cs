using System.Reflection;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FutureBinanceAPI.Models.Orders
{
    public class Order
    {
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePair()
        {
            return this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.GetValue(this) != null)
                .ToDictionary(x => ConvertKey(x.Name), 
                              x => ConvertToString(x.GetValue(this)));
        }

        private string ConvertKey(string defaultKey) => char.ToLowerInvariant(defaultKey[0]) + defaultKey.Substring(1);

        private string ConvertToString(object value)
        {
            if (value is bool)
                return value.ToString().ToLower();
            else return value is decimal @decimal ? @decimal.ToString(new CultureInfo("en-US")) : value.ToString();
        }
    }
}
