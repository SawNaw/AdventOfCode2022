using Day09.RopeMotionSimulator;

namespace Day09.Tests
{
    public class Tests
    {
        [Test]
        public void TestInput_ProcessesCorrectly_ForPartOne()
        {
            var simulator = new MotionSimulator(@"testinput.txt", 2);
            Assert.That(simulator.ExecuteAllInstructions(), Is.EqualTo(13));
        }

        [Test]
        public void TestInput_ProcessesCorrectly_ForPartTwo()
        {
            var simulator = new MotionSimulator(@"TestInputTwo.txt", 10);
            Assert.That(simulator.ExecuteAllInstructions(), Is.EqualTo(36));
        }
    }
}