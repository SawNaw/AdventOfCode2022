﻿using SawNaw.LinqExtensions.EnumerableSplit;

namespace Day01.Core
{
    /// <summary>
    /// Parses the puzzle input containing the inventory of all elves.
    /// </summary>
    public class InventoryParser
    {
        private readonly string filePath;
        private readonly string[] fileContents;

        public InventoryParser(string filePath)
        {
            this.filePath = filePath;
            fileContents = File.ReadAllLines(this.filePath);
        }

        public IEnumerable<int> CalculateTotalCaloriesOfEachElf()
        {
            return fileContents.Split(f => string.IsNullOrWhiteSpace(f)) // put each contiguous sequence of calories in its own collection
                               .Select(x => x.Select(x => int.Parse(x))) // convert each collection of strings into a collection of ints
                               .Select(x => x.Sum()); // sum each collection of ints

        }
    }
}
