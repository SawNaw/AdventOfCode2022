using Day05.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Tests
{
    internal class FileReaderTests
    {
        [Test]
        public void GetLineOfCratesFromFile_WorksCorrectly()
        {
            var reader = new FileReader(@"testinput.txt");
            var linesOfCrates = reader.GetLinesOfCratesFromFile();
            Assert.Multiple(() =>
            {
                Assert.That(linesOfCrates.ElementAt(0).Content.ElementAt(0), Is.EqualTo(' '));
                Assert.That(linesOfCrates.ElementAt(0).Content.ElementAt(1), Is.EqualTo('D'));
                Assert.That(linesOfCrates.ElementAt(0).Content.ElementAt(2), Is.EqualTo(' '));
                Assert.That(linesOfCrates.ElementAt(1).Content.ElementAt(0), Is.EqualTo('N'));
                Assert.That(linesOfCrates.ElementAt(1).Content.ElementAt(1), Is.EqualTo('C'));
                Assert.That(linesOfCrates.ElementAt(1).Content.ElementAt(2), Is.EqualTo(' '));
                Assert.That(linesOfCrates.ElementAt(2).Content.ElementAt(0), Is.EqualTo('Z'));
                Assert.That(linesOfCrates.ElementAt(2).Content.ElementAt(1), Is.EqualTo('M'));
                Assert.That(linesOfCrates.ElementAt(2).Content.ElementAt(2), Is.EqualTo('P'));
            });
        }

        [Test]
        public void GetInstructionsFromFile_WorksCorrectly()
        {
            var reader = new FileReader(@"testinput.txt");
            IEnumerable<MoveInstruction> instructions = reader.GetInstructionsFromFile();

            Assert.Multiple(() =>
            {
                Assert.That(instructions.Count(), Is.EqualTo(4));

                Assert.That(instructions.ElementAt(0).NumberOfItemsToMove, Is.EqualTo(1));
                Assert.That(instructions.ElementAt(0).Source, Is.EqualTo(2));
                Assert.That(instructions.ElementAt(0).Destination, Is.EqualTo(1));

                Assert.That(instructions.ElementAt(1).NumberOfItemsToMove, Is.EqualTo(3));
                Assert.That(instructions.ElementAt(1).Source, Is.EqualTo(1));
                Assert.That(instructions.ElementAt(1).Destination, Is.EqualTo(3));

                Assert.That(instructions.ElementAt(2).NumberOfItemsToMove, Is.EqualTo(2));
                Assert.That(instructions.ElementAt(2).Source, Is.EqualTo(2));
                Assert.That(instructions.ElementAt(2).Destination, Is.EqualTo(1));

                Assert.That(instructions.ElementAt(3).NumberOfItemsToMove, Is.EqualTo(1));
                Assert.That(instructions.ElementAt(3).Source, Is.EqualTo(1));
                Assert.That(instructions.ElementAt(3).Destination, Is.EqualTo(2));
            });
        }
    }
}
