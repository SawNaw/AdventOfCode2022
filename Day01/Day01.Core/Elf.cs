using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Core
{
    public class Elf
    {
        private readonly IEnumerable<int> individualCalories;
        public int TotalCalories => individualCalories.Sum();
        public int NumberOfFoodItems => individualCalories.Count();

        public Elf(IEnumerable<string> caloriesOfFoodItems)
        {
            this.individualCalories = caloriesOfFoodItems.Select(c => int.Parse(c));
        }
    }
}
