using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Core
{
    public class ParseResult
    {
        public IEnumerable<Elf> Elves { get; }
        public ICollection<CalorieAndPosition> CalorieAndPositions { get; }
        public ParseResult(IEnumerable<Elf> elves, ICollection<CalorieAndPosition> calorieAndPositions)
        {
            this.Elves = elves;
            this.CalorieAndPositions = calorieAndPositions;
        }
    }
}
