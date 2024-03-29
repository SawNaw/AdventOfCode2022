﻿namespace Day01.Tests
{
    internal class IntegrationTests
    {
        [TestCase("testinput.txt", 24000, 45000)]
        [TestCase("input.txt", 71502, 208191)]
        public void IntegrationTest_For_Both_Parts(string inputFile, int expectedAnswerOne, int expectedAnswerTwo)
        {
            var parser = new InventoryParser(inputFile);
            var allTotalCalories = parser.CalculateTotalCaloriesOfEachElf();
            Assert.Multiple(() =>
            {
                Assert.That(allTotalCalories.Max(), Is.EqualTo(expectedAnswerOne));
                Assert.That(Calculator.SumThreeHighest(allTotalCalories), Is.EqualTo(expectedAnswerTwo));
            });
        }
    }
}
