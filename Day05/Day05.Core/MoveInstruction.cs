using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Core
{
    internal class MoveInstruction
    {
        public int NumberOfItemsToMove { get; }
        public int Source { get; }
        public int Destination { get; }
        public MoveInstruction(string text)
        {
            var numbersOnly = GetNumbersFromLine(text);

            NumberOfItemsToMove = numbersOnly.ElementAt(0);
            Source = numbersOnly.ElementAt(1);
            Destination = numbersOnly.ElementAt(2);
        }

        private static IEnumerable<int> GetNumbersFromLine(string text)
        {
            return text.Replace("move ", "")
                       .Replace(" from ", "")
                       .Replace(" to ", "")
                       .Select(n => (int)Char.GetNumericValue(n));
        }
    }
}
