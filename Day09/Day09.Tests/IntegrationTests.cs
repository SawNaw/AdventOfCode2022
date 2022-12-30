using Day09.RopeMotionSimulator;

namespace Day09.Tests
{
    public class Tests
    {
        [Test]
        public void TestInput_ProcessesCorrectly()
        {
            var simulator = new MotionSimulator(@"testinput.txt");
            Assert.That(simulator.ExecuteInstructions(), Is.EqualTo(13));
        }
    }
}