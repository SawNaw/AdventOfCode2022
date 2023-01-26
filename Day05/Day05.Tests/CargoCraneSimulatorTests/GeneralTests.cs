using Day05.Core;

namespace Day05.Tests.CargoCraneSimulatorTests
{
    internal class GeneralTests
    {
        [Test]
        public void Constructor_AssignsItems_Correctly()
        {
            var lines = new FileReader(@"testinput.txt").GetLinesOfCratesFromFile();
            var stacks = new CargoCraneSimulator(lines);

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
            var stacks = new CargoCraneSimulator(lines);

            Assert.Multiple(() =>
            {
                Assert.That(stacks.Content.ElementAt(0).Count(), Is.EqualTo(2));
                Assert.That(stacks.Content.ElementAt(1).Count(), Is.EqualTo(3));
                Assert.That(stacks.Content.ElementAt(2).Count(), Is.EqualTo(1));
            });
        }
    }
}
