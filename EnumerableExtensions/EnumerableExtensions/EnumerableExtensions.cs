namespace EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Splits a collection into multiple collections based on the given condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the collection.</typeparam>
        /// <param name="source">The collection to split.</param>
        /// <param name="predicate">The condition for the separating element.</param>
        /// <returns>A collection containing the results of the split.</returns>
        /// <example>
        /// For a collection of integers {1, 3, 2, 0, 3, 6, 0, 3, 5}
        /// myList.Split(i => i == 0)
        /// will return these collections: {1, 3, 2}, {3, 6}, and {3, 5}
        /// </example>
        /// <remarks>
        /// Think of it as <seealso cref="string.Split(char[]?)"/> for collections.
        /// </remarks>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source,
                                                                       Func<TSource, bool> predicate)
        {
            var result = new List<List<TSource>>();
            var subCollection = new List<TSource>();

            foreach (TSource item in source)
            {
                if (!predicate(item))
                {
                    subCollection.Add(item);
                }
                else
                {
                    result.Add(subCollection);
                    subCollection = new List<TSource>();
                }
            }
            result.Add(subCollection);

            return result.Where(r => r.Any()); // to avoid returning the empty collections. Maybe fix logic so that the .Where() isn't needed.
        }
    }
}