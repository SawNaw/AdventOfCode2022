namespace EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Splits a collection into multiple collections based on a separating condition.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="source">The collection to split.</param>
        /// <param name="separator">The condition for the separating element.</param>
        /// <returns>A collection containing the results of the split.</returns>
        /// 
        /// <example>
        /// string[] things = {"pie", "apple", "cake", "mud-pie", "nuts", "plum", "mud-spread", "milk", "butter"};
        /// var edibleThings = things.Split(m => m.StartsWith("mud"));
        /// 
        /// edibleThings will contain these collections: 
        ///    {"pie", "apple", "cake"}
        ///    {"nuts", "plum"}
        ///    {"milk", "butter"}
        /// </example>
        /// 
        /// <exception cref="ArgumentNullException">Thrown when any provided argument is null.</exception>
        /// 
        /// <remarks>
        /// Think of it as <seealso cref="string.Split(char[]?)"/> for collections.
        /// </remarks>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, Func<T, bool> separator)
        {
            if (separator == null || source == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }

            var result = new List<List<T>>();
            var subCollection = new List<T>();

            foreach (T item in source)
            {
                if (!separator(item))
                {
                    subCollection.Add(item);
                }
                else if (subCollection.Any())
                {
                    result.Add(subCollection);
                    subCollection = new List<T>();
                }
            }

            if (subCollection.Any())
            {
                result.Add(subCollection);
            }

            return result;
        }

        /// <summary>
        /// Splits a collection into multiple collections using given separators.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="source">The collection to split.</param>
        /// <param name="separator">The separating elements.</param>
        /// <returns>A collection containing the results of the split.</returns>
        /// 
        /// <example>
        /// string[] things = {"pie", "apple", "cake", "mud-pie", "nuts", "plum", "mud-spread", "milk", "butter"};
        /// var edibleThings = things.Split(m => m.Contains("mud-pie", "mud-spread"));
        /// 
        /// edibleThings will contain these collections: 
        ///    {"pie", "apple", "cake"}
        ///    {"nuts", "plum"}
        ///    {"milk", "butter"}
        /// </example>
        /// 
        /// <exception cref="ArgumentNullException">Thrown when any provided argument is null.</exception>
        /// 
        /// <remarks>
        /// Think of it as <seealso cref="string.Split(char[]?)"/> for collections.
        /// </remarks>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, params T[] separator)
        {
            return Split(source, t => separator.Contains(t));
        }
    }
}