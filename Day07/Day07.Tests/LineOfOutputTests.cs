using Day07.Filesystem;

namespace Day07.Tests
{
    internal class LineOfOutputTests
    {
        [TestCase("4060174 j", 4060174, "j")]
        [TestCase("8033020 dafd.log", 8033020, "dafd.log")]
        [TestCase("5626152 zsdf.ext", 5626152, "zsdf.ext")]
        [TestCase("7214296 kd", 7214296, "kd")]
        public void Files_AreProcessed_Correctly(string input, int expectedSize, string expectedName)
        {
            var line = new LineOfOutput(input);

            Assert.Multiple(() =>
            {
                Assert.That(line.Content, Is.EqualTo(input));
                Assert.That(line.Size, Is.EqualTo(expectedSize));
                Assert.That(line.Name, Is.EqualTo(expectedName));
                Assert.That(line.IsFile, Is.True);
                Assert.That(line.IsDirectory, Is.False);
            });
        }

        [TestCase("dir afdsa", "afdsa")]
        [TestCase("dir zsafd", "zsafd")]
        public void Directories_AreProcessed_Correctly(string input, string expectedName)
        {
            var line = new LineOfOutput(input);

            Assert.Multiple(() =>
            {
                Assert.That(line.Content, Is.EqualTo(input));
                Assert.That(line.Size, Is.EqualTo(0));
                Assert.That(line.Name, Is.EqualTo(expectedName));
                Assert.That(line.IsFile, Is.False);
                Assert.That(line.IsDirectory, Is.True);
            });
        }
    }
}
