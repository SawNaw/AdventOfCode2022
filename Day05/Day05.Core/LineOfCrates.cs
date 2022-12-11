using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Core
{
    internal class LineOfCrates
    {
        public List<char> Content { get; }
        public LineOfCrates(string line)
        {
            Content = new List<char>();

            for (int i = 0; i < line.Length; i += 4) // a new crate [X] starts every 4 characters
            {
                var substring = line.Substring(i, 3); // substring now contains [X]

                // extract the X from [X] and store it
                // or mark as "no crate"
                Content.Add(string.IsNullOrWhiteSpace(substring) ? ' ' : (substring[1]));
            }
        }
    }
}
