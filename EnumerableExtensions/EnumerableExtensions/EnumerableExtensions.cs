namespace EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Splits a collection into multiple collections using a given condition as a separator.
        /// </summary>
        /// 
        /// <typeparam name="TSource">The type of the elements in the collection.</typeparam>
        /// <param name="source">The collection to split.</param>
        /// <param name="separator">The condition for the separating element.</param>
        /// <returns>A collection containing the results of the split.</returns>
        /// 
        /// <example>
        /// string[] things = {"pie", "apple", "cake", "mud", "nuts", "plum", "mud", "milk", "butter"}
        /// var edibleThings = things.Split(m => m == "mud")
        /// 
        /// edibleThings will contain these collections: 
        ///    {"pie", "apple", "cake"}
        ///    {"nuts", "plum"}
        ///    {"milk", "butter"}
        /// </example>
        /// 
        /// <remarks>
        /// Think of it as <seealso cref="string.Split(char[]?)"/> for collections.
        /// </remarks>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source,
                                                                       Func<TSource, bool> separator)
        {
            var result = new List<List<TSource>>();
            var subCollection = new List<TSource>();

            foreach (TSource item in source)
            {
                if (!separator(item))
                {
                    subCollection.Add(item);
                }
                else if (subCollection.Any())
                {
                    result.Add(subCollection);
                    subCollection = new List<TSource>();
                }
            }

            if (subCollection.Any())
            { 
                result.Add(subCollection);
            }

            return result;
        }
    }
}