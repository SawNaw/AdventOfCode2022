using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Core
{
    internal class LineOfCrates
    {
        public IReadOnlyCollection<char> Content => _content;
        private List<char> _content { get; }
        public LineOfCrates(string line)
        {
            _content = new List<char>();
            AddCratesToLine(line);
        }

        private void AddCratesToLine(string line)
        {
            for (int i = 0; i < line.Length; i += 4) // a new crate [X] starts every 4 characters
            {
                var substring = line.Substring(i, 3); // substring now contains [X]

                // extract the X from [X] and store it
                // or mark as "no crate"
                _content.Add(string.IsNullOrWhiteSpace(substring) ? ' ' : (substring[1]));
            }
        }
    }
}
