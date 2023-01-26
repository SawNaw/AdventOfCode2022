namespace Day04.Core
{
    internal class SectionAssignmentReader
    {
        private readonly string[] fileContents;
        public SectionAssignmentReader(string filepath)
        {
            fileContents = File.ReadAllLines(filepath);
        }

        public int GetFullyContainedPairs()
        {
            return GetPairs(DetectionModes.FullyContained);
        }

        public int GetOverlappingPairs()
        {
            return GetPairs(DetectionModes.Overlapping);
        }

        private int GetPairs(DetectionModes modes)
        {
            int totalPairs = 0;
            foreach (var line in fileContents)
            {
                var pair = line.Split(',');
                var section1 = GetSectionFromRange(pair[0]);
                var section2 = GetSectionFromRange(pair[1]);
                if (modes == DetectionModes.FullyContained)
                {
                    if (OneFullyContainsTheOther(section1, section2))
                    {
                        totalPairs++;
                    }
                }
                else if (modes == DetectionModes.Overlapping)
                {
                    if (OneOverlapsTheOther(section1, section2))
                    {
                        totalPairs++;
                    }
                }

            }
            return totalPairs;
        }

        private static Section GetSectionFromRange(string range)
        {
            var startAndEnd = range.Split('-');
            return new Section(int.Parse(startAndEnd[0]), int.Parse(startAndEnd[1]));
        }

        private static bool OneFullyContainsTheOther(Section first, Section second)
        {
            return first.FullyContains(second) || second.FullyContains(first);
        }

        private static bool OneOverlapsTheOther(Section first, Section second)
        {
            return first.Overlaps(second) || second.Overlaps(first);
        }

        private enum DetectionModes
        {
            FullyContained,
            Overlapping,
        }
    }
}
