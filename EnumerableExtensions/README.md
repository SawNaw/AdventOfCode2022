# EnumerableExtensions

SplitBy - Splits a sequence into multiple sequences based on the given condition.

For example, given a collection of integers {1, 3, 2, 0, 3, 6, 0, 3, 5}
  myList.SplitBy(m => m == 0)
should return three collections containing {1, 3, 2}, {3, 6}, and {3, 5}
