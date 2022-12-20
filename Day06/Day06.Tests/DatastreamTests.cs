using Day06.Core;

namespace Day06.Tests
{
    public class DatastreamTests
    {
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void First_Marker_Detected_Correctly(string input, int expected)
        {
            var stream = new Datastream(input);

            // Collections are zero-based, the problem is not, therefore adjust by one.
            Assert.That(stream.FindAllMarkers().First().MarkerPosition, Is.EqualTo(expected - 1)); 
        }


    }
}