using System.Collections.Generic;

namespace Utility.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            if (collection == null)
            {
                return true;
            }

            return collection.Count <= 0;
        }
    }
}