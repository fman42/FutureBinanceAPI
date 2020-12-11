using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FutureBinanceAPI.Models.Orders;

namespace FutureBinanceAPI.Tools.Extensions
{
    internal static class OrderExtension
    {
        public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePair(this IOrder order)
        {
            return order.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.GetValue(order) is { })
                .ToDictionary(x => ConvertKey(x.Name), 
                              x => ConvertToString(x.GetValue(order)));
        }

        private static string ConvertKey(string defaultKey) => char.ToLowerInvariant(defaultKey[0]) + defaultKey.Substring(1);

        private static string ConvertToString(object value)
        {
            if (value is bool)
                return $"{value}".ToLower();
            else return value.GetType() == typeof(decimal) ? Convert.ToDecimal(value).ToString(new CultureInfo("en-US")) : value.ToString();
        }
    }
}
