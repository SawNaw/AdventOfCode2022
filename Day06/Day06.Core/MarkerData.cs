using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06.Core
{
    internal class MarkerData
    {
        /// <summary>
        /// The substring of unique characters within which the marker was found.
        /// </summary>
        public string Substring { get; }

        /// <summary>
        /// The zero-based position of the marker.
        /// </summary>
        public int MarkerPosition { get; }
        public MarkerData(string substring, int markerPosition)
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
