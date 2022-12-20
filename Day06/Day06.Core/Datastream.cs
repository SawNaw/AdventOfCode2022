using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Core
{
    internal class Datastream
    {
        private const int StartOfPacketSequenceSize = 4;
        public string Content { get; }

        public Datastream(string datastream)
        {
            this.Content = datastream;
        }

        public StartOfPacketMarkerData FindFirstStartOfPacketMarker()
        {
            for (int i = 0; i < this.Content.Length - 3; i++) 
            {
                var fourLetterSubstring = Content.Substring(i, StartOfPacketSequenceSize);
                if (StringContainsDistinctCharacters(fourLetterSubstring))
                {
                    return new StartOfPacketMarkerData(fourLetterSubstring, i + 3);
                }
            }

            throw new ArgumentException("Marker not found: are you sure the input file is correct?");
        }

        private static bool StringContainsDistinctCharacters(string str) 
        {
            return str.Distinct().Count() == str.Length;
        }
    }
}
