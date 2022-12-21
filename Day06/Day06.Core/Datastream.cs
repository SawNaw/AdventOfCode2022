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
        private const int StartOfMessageSequenceSize = 14;
        public string Content { get; }

        public Datastream(string datastream)
        {
            this.Content = datastream;
        }

        public int FindFirstStartOfPacketMarker()
        {
            return FindFirstStartMarker(MarkerTypes.StartOfPacket);
        }

        public int FindFirstStartOfMessageMarker()
        {
            return FindFirstStartMarker(MarkerTypes.StartOfMessage);
        }

        private int FindFirstStartMarker(MarkerTypes markerType)
        {
            int sequenceSize = GetSequenceLength(markerType);

            for (int i = 0; i < this.Content.Length - (sequenceSize - 1); i++)
            {
                var sequence = Content.Substring(i, sequenceSize);
                if (AllCharactersAreUnique(sequence))
                {
                    return i + (sequenceSize - 1);
                }
            }

            throw new ArgumentException("Marker not found: are you sure the input file is correct?");
        }

        private static int GetSequenceLength(MarkerTypes markerTypes)
        {
            return markerTypes == MarkerTypes.StartOfPacket
                                ? StartOfPacketSequenceSize
                                : StartOfMessageSequenceSize;
        }

        private static bool AllCharactersAreUnique(string str)
        {
            return str.Distinct().Count() == str.Length;
        }
    }
}
