using System.Collections.Generic;

namespace Utility.Extensions
{
    public static class ListExtensions
    {
        public static T Pop<T>(this IList<T> list, int index = -1)
        {
            if (index < 0)
            {
                index = list.Count - 1;
            }

            if (index >= 0 && index < list.Count)
            {
                var t = list[index];
                list.RemoveAt(index);
                return t;
            }

            return default;
        }

        public static T Peek<T>(this IList<T> list)
        {
            return list.IsEmpty() ? default : list[0];
        }
    }
}