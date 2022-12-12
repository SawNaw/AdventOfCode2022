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
        private string filePath;
        public ParseResult Parse()
        {
            var lines = File.ReadAllLines(filePath);

            var parsedLines = lines.SplitBy(l => string.IsNullOrWhiteSpace(l))
                                   .Select(e => new Elf(e));

            var highestCalorieListAndPosition = GetThreeHighestCalorieListAndPosition(parsedLines.ToList());

            return new ParseResult(parsedLines, highestCalorieListAndPosition);
        }

        private ICollection<CalorieAndPosition> GetThreeHighestCalorieListAndPosition(IReadOnlyList<Elf> list)
        {
            var source = new List<Elf>(list);
            List<CalorieAndPosition> topThree = new();

            for (int i = 0; i < 3; i++)
            {
                var max = source.MaxBy(l => l.TotalCalories);
                var index = source.FindIndex(l => l.TotalCalories == max.TotalCalories);
                topThree.Add(new CalorieAndPosition(max.TotalCalories, index));
                source.Remove(max);
            }

            return topThree;
        }

        public FileParser(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
