using EnumerableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Core
{
    public class FileParser
    {
        private string FilePath { get; }

        public ParseResult Parse()
        {
            var lines = File.ReadAllLines(FilePath);

            var parsedLines = lines.SplitBy(l => string.IsNullOrWhiteSpace(l))
                                   .Select(e => new Elf(e));

            var highestCalorieListAndPosition = GetThreeHighestCalorieListAndPosition(parsedLines);

            return new ParseResult(parsedLines, highestCalorieListAndPosition);
        }

        private static ICollection<CalorieAndPosition> GetThreeHighestCalorieListAndPosition(IEnumerable<Elf> list)
        {
            var source = new List<Elf>(list); // copy the list before we mess around with it
            List<CalorieAndPosition> topThree = new();

            // Get the top 3 by getting the top, storing it, deleting it, and then getting the new top.
            for (int i = 0; i < 3; i++)
            {
                var max = source.MaxBy(l => l.TotalCalories);
                var index = source.FindIndex(l => l.TotalCalories == max!.TotalCalories);
                topThree.Add(new CalorieAndPosition(max!.TotalCalories, index));
                source.Remove(max);
            }

            return topThree;
        }

        public FileParser(string filePath)
        {
            this.FilePath = filePath;
        }
    }
}
