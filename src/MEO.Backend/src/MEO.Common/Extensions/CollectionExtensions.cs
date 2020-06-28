using System.Collections.Generic;
using System.Linq;

namespace MEO.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @list)
            => @list is null || !@list.Any();

        public static bool HasAny<T>(this IEnumerable<T> @list) 
            => !@list.IsNullOrEmpty();
    }
}
