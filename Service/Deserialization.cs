using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using Routy;

namespace Service
{
    public static class Deserialization
    {
        private static readonly Dictionary<Type, Parser<object>> Parsers = new Dictionary<Type, Parser<object>>
        {
            [typeof(string)] = s => s,
            [typeof(bool)] = s => bool.Parse(s),
            [typeof(int)] = s => int.Parse(s)
        };

        public static T DeserializeFormUrlencoded<T>(Stream stream) where T : new()
        {
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                var decodedContent = HttpUtility.UrlDecode(content);
                var nvc = HttpUtility.ParseQueryString(decodedContent);
                var t = new T();
                foreach (var kvp in nvc.AllKeys)
                {
                    var pi = typeof(T).GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
                    if (pi == null)
                        continue;

                    if (Parsers.TryGetValue(pi.PropertyType, out var parser))
                        pi.SetValue(t, parser(nvc[kvp]), null);
                    else
                        throw new NotImplementedException("21");
                }
                return t;
            }
        }
    }
}