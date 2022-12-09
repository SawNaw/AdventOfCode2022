namespace Day03.Tests
{
    public class Tests
    {

        [TestCase('a', 1)]
        [TestCase('c', 3)]
        [TestCase('z', 26)]
        [TestCase('A', 27)]
        [TestCase('D', 30)]
        [TestCase('Z', 52)]
        public void GetPriority_ReturnsCorrectPriorities(char letter, int expected)
        {
            Assert.That(Priority.GetPriority('a'), Is.EqualTo(1));
        }

        [Test]
        public void GetSumOfPrioritiesOfAllCommonItems_Works()
        {
            var result = Priority.GetSumOfPrioritiesOfAllCommonItems(@"testinput.txt");
            Assert.That(result, Is.EqualTo(157));
        }

        [Test]
        public void GetSumOfPrioritiesOfAllThreeElfGroups_Works()
        {
            var result = Priority.GetSumOfPrioritiesOfAllThreeElfGroups(@"testinput.txt");
            Assert.That(result, Is.EqualTo(70));
        }
    }
}