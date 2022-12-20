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

        public MarkerData FindFirstStartOfPacketMarker()
        {
            return FindFirstStartMarker(MarkerTypes.StartOfPacket);
        }

        public MarkerData FindFirstStartOfMessageMarker()
        {
            return FindFirstStartMarker(MarkerTypes.StartOfMessage);
        }

        private MarkerData FindFirstStartMarker(MarkerTypes markerType)
        {
            int sequenceSize = GetSequenceLength(markerType);

            for (int i = 0; i < this.Content.Length - (sequenceSize - 1); i++)
            {
                var sequence = Content.Substring(i, sequenceSize);
                if (AllCharactersAreUnique(sequence))
                {
                    return new MarkerData(sequence, i + (sequenceSize - 1));
                }
            }

            throw new ArgumentException("Marker not found: are you sure the input file is correct?");
        }

        private int GetSequenceLength(MarkerTypes markerTypes)
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
