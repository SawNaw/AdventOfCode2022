using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Core
{
    internal class StartOfPacketMarkerData
    {
        /// <summary>
        /// The substring of unique characters within which the marker was found.
        /// </summary>
        public string Substring { get; }

        /// <summary>
        /// The zero-based position of the marker.
        /// </summary>
        public int MarkerPosition { get; }
        public StartOfPacketMarkerData(string substring, int markerPosition)
        {
            if (substring.Distinct().Count() < substring.Length) 
            { 
                throw new ArgumentException($"{substring} does not contain all unique characters.", nameof(substring));
            }

            Substring = substring;
            MarkerPosition = markerPosition;
        }
    }
}
