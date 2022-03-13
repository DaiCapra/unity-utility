using System.Collections.Generic;

namespace Utility.Extensions
{
    public static class DictionaryExtensions
    {
        public static TV Get<TK, TV>(this IDictionary<TK, TV> dict, TK key)
        {
            if (dict == null || !dict.ContainsKey(key))
            {
                return default;
            }

            return dict[key];
        }

        public static void Set<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV value)
        {
            if (dict == null)
            {
                return;
            }

            if (!dict.ContainsKey(key))
            {
                dict.Add(key, value);
            }
            else
            {
                dict[key] = value;
            }
        }

        public static bool TryGet<TK, TV>(this IDictionary<TK, TV> dict, TK key, out TV value)
        {
            value = default;
            if (dict == null || !dict.ContainsKey(key))
            {
                return false;
            }

            value = dict[key];

            return true;
        }

        public static TV GetOrMake<TK, TV>(this IDictionary<TK, TV> dict, TK key) where TV : new()
        {
            if (!dict.TryGetValue(key, out TV v))
            {
                v = new TV();
                dict[key] = v;
            }

            return v;
        }
    }
}