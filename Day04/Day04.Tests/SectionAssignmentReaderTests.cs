using Day04.Core;

namespace Day04.Tests
{
    internal class SectionAssignmentReaderTests
    {
        [Test]
        public void IntegrationTestOne()
        {
            var reader = new SectionAssignmentReader(@"testinput.txt");
            int number = reader.GetFullyContainedPairs();
            Assert.That(number, Is.EqualTo(2));
        }

        [Test]
        public void IntegrationTestTwo()
        {
            var reader = new SectionAssignmentReader(@"testinput.txt");
            int number = reader.GetOverlappingPairs();
            Assert.That(number, Is.EqualTo(4));
        }
    }
}
