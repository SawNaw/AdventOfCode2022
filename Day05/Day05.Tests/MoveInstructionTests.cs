using Day05.Core;

namespace Day05.Tests
{
    public class MoveInstructionTests
    {
        [TestCase("move 3 from 6 to 2", 3, 6, 2)]
        [TestCase("move 5 from 6 to 7", 5, 6, 7)]
        [TestCase("move 6 from 2 to 5", 6, 2, 5)]
        public void Constructor_ParsesCorrectly(string text, int expectedNumToMove, int expectedSource, int expectedDestination)
        {
            var instruction = new MoveInstruction(text);
            Assert.Multiple(() =>
            {
                Assert.That(instruction.NumberOfItemsToMove, Is.EqualTo(expectedNumToMove));
                Assert.That(instruction.Source, Is.EqualTo(expectedSource));
                Assert.That(instruction.Destination, Is.EqualTo(expectedDestination));
            });
        }
    }
}