using Day09.RopeMotionSimulator;

namespace Day09.Tests
{
    public class Tests
    {
        [Test]
        public void TestInput_ProcessesCorrectly_ForPartOne()
        {
            var simulator = new MotionSimulator(@"testinput.txt", MotionSimulator.Modes.PartOne);
            Assert.That(simulator.ExecuteInstructions(), Is.EqualTo(13));
        }

        [Test]
        public void TestInput_ProcessesCorrectly_ForPartTwo()
        {
            var simulator = new MotionSimulator(@"TestInputTwo.txt", MotionSimulator.Modes.PartTwo);
            Assert.That(simulator.ExecuteInstructions(), Is.EqualTo(36));
        }
    }
}