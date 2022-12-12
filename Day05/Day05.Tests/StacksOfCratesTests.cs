using Day05.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Tests
{
    internal class StacksOfCratesTests
    {
        [Test]
        public void Constructor_AssignsItems_Correctly()
        {
            var lines = new FileReader(@"testinput.txt").GetLinesOfCratesFromFile();
            var stacks = new StacksOfCrates(lines);

            Assert.Multiple(() =>
            {
                Assert.That(stacks.Content.ElementAt(0).ElementAt(1), Is.EqualTo('Z'));
                Assert.That(stacks.Content.ElementAt(0).ElementAt(0), Is.EqualTo('N'));

                Assert.That(stacks.Content.ElementAt(1).ElementAt(2), Is.EqualTo('M'));
                Assert.That(stacks.Content.ElementAt(1).ElementAt(1), Is.EqualTo('C'));
                Assert.That(stacks.Content.ElementAt(1).ElementAt(0), Is.EqualTo('D'));

                Assert.That(stacks.Content.ElementAt(2).ElementAt(0), Is.EqualTo('P'));
            });
        }

        [Test]
        public void Constructor_AssignsItems_WithCorrectCounts()
        {
            var lines = new FileReader(@"testinput.txt").GetLinesOfCratesFromFile();
            var stacks = new StacksOfCrates(lines);

            Assert.Multiple(() =>
            {
                Assert.That(stacks.Content.ElementAt(0).Count(), Is.EqualTo(2));
                Assert.That(stacks.Content.ElementAt(1).Count(), Is.EqualTo(3));
                Assert.That(stacks.Content.ElementAt(2).Count(), Is.EqualTo(1));
            });
        }

        [Test]
        public void ExecuteInstruction_Works_ForOneInstruction()
        {
            var lines = new FileReader(@"testinput.txt").GetLinesOfCratesFromFile();
            var stacks = new StacksOfCrates(lines);

            var instructions = new List<MoveInstruction>() { new MoveInstruction("move 1 from 2 to 3") };
            stacks.ExecuteInstruction(instructions);

            Assert.Multiple(() =>
            {
                Assert.That(stacks.Content.ElementAt(0).ElementAt(1), Is.EqualTo('Z'));
                Assert.That(stacks.Content.ElementAt(0).ElementAt(0), Is.EqualTo('N'));

                Assert.That(stacks.Content.ElementAt(1).ElementAt(1), Is.EqualTo('M'));
                Assert.That(stacks.Content.ElementAt(1).ElementAt(0), Is.EqualTo('C'));

                Assert.That(stacks.Content.ElementAt(2).ElementAt(1), Is.EqualTo('P'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(0), Is.EqualTo('D'));
            });
        }

        /// <summary>
        /// This test uses the sample input, and runs the series of sample instructions on the website.
        /// </summary>
        [Test]
        public void ExecuteInstruction_Works_ForMultipleInstructions()
        {
            var lines = new FileReader(@"testinput.txt").GetLinesOfCratesFromFile();
            var stacks = new StacksOfCrates(lines);
            List<MoveInstruction> instructions = new List<MoveInstruction>()
            {
                new MoveInstruction("move 1 from 2 to 1"),
                new MoveInstruction("move 3 from 1 to 3"),
                new MoveInstruction("move 2 from 2 to 1"),
                new MoveInstruction("move 1 from 1 to 2")
            };

            stacks.ExecuteInstruction(instructions);

            Assert.Multiple(() =>
            {
                Assert.That(stacks.Content.ElementAt(0).Count, Is.EqualTo(1));
                Assert.That(stacks.Content.ElementAt(0).ElementAt(0), Is.EqualTo('C'));

                Assert.That(stacks.Content.ElementAt(1).Count, Is.EqualTo(1));
                Assert.That(stacks.Content.ElementAt(1).ElementAt(0), Is.EqualTo('M'));

                Assert.That(stacks.Content.ElementAt(2).Count, Is.EqualTo(4));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(3), Is.EqualTo('P'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(2), Is.EqualTo('D'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(1), Is.EqualTo('N'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(0), Is.EqualTo('Z'));
            });
        }
    }
}
