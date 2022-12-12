using Day05.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Tests.CargoCraneSimulatorPartTwoTests
{
    internal class PartTwoTests
    {

        [Test]
        public void ExecuteInstruction_Works_ForOneInstruction()
        {
            var lines = new FileReader(@"testinput.txt").GetLinesOfCratesFromFile();
            var stacks = new CargoCraneSimulator(lines);

            var instructions = new List<MoveInstruction>() { new MoveInstruction("move 2 from 1 to 3") };
            stacks.ExecuteInstructions(instructions, CrateMoverVersions.CrateMover9001);

            Assert.Multiple(() =>
            {
                Assert.That(stacks.Content.ElementAt(0).Count, Is.EqualTo(0));

                Assert.That(stacks.Content.ElementAt(1).ElementAt(0), Is.EqualTo('D'));
                Assert.That(stacks.Content.ElementAt(1).ElementAt(1), Is.EqualTo('C'));
                Assert.That(stacks.Content.ElementAt(1).ElementAt(2), Is.EqualTo('M'));

                Assert.That(stacks.Content.ElementAt(2).ElementAt(0), Is.EqualTo('N'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(1), Is.EqualTo('Z'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(2), Is.EqualTo('P'));
            });
        }

        /// <summary>
        /// This test uses the sample input, and runs the series of sample instructions on the website.
        /// </summary>
        [Test]
        public void ExecuteInstruction_Works_ForMultipleInstructions()
        {
            var reader = new FileReader(@"testinput.txt");
            var lines = reader.GetLinesOfCratesFromFile();
            var instructions = reader.GetInstructionsFromFile();

            var stacks = new CargoCraneSimulator(lines);

            string message = stacks.ExecuteInstructions(instructions, CrateMoverVersions.CrateMover9001);

            Assert.Multiple(() =>
            {
                Assert.That(stacks.Content.ElementAt(0).Single(), Is.EqualTo('M'));

                Assert.That(stacks.Content.ElementAt(1).Single(), Is.EqualTo('C'));

                Assert.That(stacks.Content.ElementAt(2).Count, Is.EqualTo(4));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(0), Is.EqualTo('D'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(1), Is.EqualTo('N'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(2), Is.EqualTo('Z'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(3), Is.EqualTo('P'));

                Assert.That(message, Is.EqualTo("MCD"));
            });
        }

        [Test]
        public void ExecuteInstruction_Returns_CorrectMessage_UsingTopItem_OfEachStack()
        {
            var reader = new FileReader(@"testinput.txt");
            var lines = reader.GetLinesOfCratesFromFile();
            var instructions = reader.GetInstructionsFromFile();
            var stacks = new CargoCraneSimulator(lines);

            Assert.That(stacks.ExecuteInstructions(instructions, CrateMoverVersions.CrateMover9000), Is.EqualTo("CMZ"));
        }
    }
}
