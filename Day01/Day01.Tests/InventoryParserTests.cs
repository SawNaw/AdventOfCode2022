﻿namespace Day01.Tests
{
    internal class InventoryParserTests
    {
        public class CalorieListTests
        {
            [Test]
            public void Parse_Returns_CorrectNumberOfLists()
            {
                var parser = new InventoryParser(@"testinput.txt");
                var result = parser.CalculateTotalCaloriesOfEachElf();
                Assert.That(result.Count, Is.EqualTo(5));
            }
        }
    }
}
