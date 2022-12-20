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

        public IEnumerable<StartOfPacketMarkerData> FindAllMarkers()
        {
            List<StartOfPacketMarkerData> markerData = new();

            for (int i = 0; i < this.Content.Length - 3; i++) 
            {
                var fourLetterSubstring = Content.Substring(i, StartOfPacketSequenceSize);
                if (StringContainsDistinctCharacters(fourLetterSubstring))
                {
                    markerData.Add(new StartOfPacketMarkerData(fourLetterSubstring, i + 3));
                }
            }
            return markerData;
        }

        private static bool StringContainsDistinctCharacters(string str) 
        {
            return str.Distinct().Count() == str.Length;
        }
    }
}
