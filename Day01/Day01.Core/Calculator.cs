using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Core
{
    internal static class Calculator
    {
        internal static int SumThreeHighest(IEnumerable<int> source)
        {
            List<int> copy = new(source); // copy the collection before messing with it
            List<int> topThree = new();

            // Get the top 3 by getting the top, storing it, deleting it, and then getting the new top.
            for (int i = 0; i < 3; i++)
            {
                var max = copy.Max();
                topThree.Add(copy.Max());
                copy.Remove(max);
            }

            return topThree.Sum();
        }
    }
}
