namespace EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Splits a sequence into multiple sequences based on the given condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the collection.</typeparam>
        /// <param name="source">The source collection to split.</param>
        /// <param name="predicate">The condition for the separating element.</param>
        /// <returns>A collection containing the results of the split.</returns>
        /// <example>
        /// For a collection of integers {1, 3, 2, 0, 3, 6, 0, 3, 5}
        /// myList.SplitBy(m => m == 0)
        /// should return three collections containing {1, 3, 2}, {3, 6}, and {3, 5}
        /// </example>
        public static IEnumerable<IEnumerable<TSource>> SplitBy<TSource>(this IEnumerable<TSource> source,
                                                                       Func<TSource, bool> predicate)
        {
            ICollection<ICollection<TSource>> result = new List<ICollection<TSource>>();
            ICollection<TSource> innerCollection = new List<TSource>();

            foreach (TSource item in source) 
            {
                if (!predicate(item))
                {
                    innerCollection.Add(item);

                }
                else
                {
                    result.Add(innerCollection);
                    innerCollection = new List<TSource>();
                    continue;
                }
            }
            result.Add(innerCollection);

            return result.Where(r => r.Any()); // to avoid returning the empty collections. Maybe fix logic so that the .Where() isn't needed.
        }
    }
}