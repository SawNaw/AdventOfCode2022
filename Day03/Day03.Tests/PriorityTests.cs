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
    }
}