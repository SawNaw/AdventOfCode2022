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

        private ICollection<CalorieAndPosition> GetThreeHighestCalorieListAndPosition(List<Elf> list)
        {
            List<CalorieAndPosition> topThree = new();
            var max = list.MaxBy(l => l.TotalCalories);
            var index = list.FindIndex(l => l.TotalCalories == max.TotalCalories);
            topThree.Add(new CalorieAndPosition(max.TotalCalories, index));
            list.Remove(max);

            var max2 = list.MaxBy(l => l.TotalCalories);
            var index2 = list.FindIndex(l => l.TotalCalories == max2.TotalCalories);
            topThree.Add(new CalorieAndPosition(max2.TotalCalories, index2));
            list.Remove(max2);

            var max3 = list.MaxBy(l => l.TotalCalories);
            var index3 = list.FindIndex(l => l.TotalCalories == max3.TotalCalories);
            topThree.Add(new CalorieAndPosition(max3.TotalCalories, index3));
            list.Remove(max3);


            return topThree;
        }

        public FileParser(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
