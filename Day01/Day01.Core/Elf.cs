using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Core
{
    public class Elf
    {
        private readonly IReadOnlyList<int> caloriesOfFoodItems;
        public int TotalCalories => caloriesOfFoodItems.Sum();
        public int NumberOfFoodItems => caloriesOfFoodItems.Count;

        public Elf(IEnumerable<int> caloriesOfFoodItems)
        {
            this.caloriesOfFoodItems = caloriesOfFoodItems.ToList();
        }

        public Elf(IEnumerable<string> caloriesOfFoodItems)
        {
            this.caloriesOfFoodItems = caloriesOfFoodItems.Select(c => int.Parse(c))
                                                          .ToList();
        }
    }
}
