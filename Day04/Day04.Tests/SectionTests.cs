using Day04.Core;

namespace Day04.Tests
{
    public class SectionTests

    {
        [Test]
        public void FullyContains_ReturnsTrue_ForFullyContainedSection()
        {
            var section1 = new Section(2, 8);
            var section2 = new Section(3, 7);

            Assert.That(section1.FullyContains(section2), Is.True);
        }

        [Test]
        public void FullyContains_ReturnsTrue_WhenBothSections_HaveIdenticalEnd()
        {
            var section1 = new Section(4, 6);
            var section2 = new Section(5, 6);

            Assert.That(section1.FullyContains(section2), Is.True);
        }

        [Test]
        public void FullyContains_ReturnsFalse_ForExternalSection()
        {
            var section1 = new Section(5, 7);
            var section2 = new Section(7, 9);

            Assert.That(section1.FullyContains(section2), Is.False);
        }

        [Test]
        public void FullyContains_ReturnsFalse_ForOverlapWithoutFullContainment()
        {
            var section1 = new Section(5, 7);
            var section2 = new Section(6, 9);

            Assert.That(section1.FullyContains(section2), Is.False);
        }

        [TestCase(5, 7, 7, 9)]
        [TestCase(2, 8, 3, 7)]
        [TestCase(6, 6, 4, 6)]
        [TestCase(2, 6, 4, 8)]
        public void Overlaps_ReturnsTrue_ForOverlappingSections(int section1start, int section1end, int section2start, int section2end)
        {
            var section1 = new Section(section1start, section1end);
            var section2 = new Section(section2start, section2end);

            Assert.That(section1.Overlaps(section2), Is.True);
        }

        [TestCase(2, 4, 6, 8)]
        [TestCase(7, 9, 3, 6)]
        public void Overlaps_ReturnsFalse_ForNonOverlappingSections(int section1start, int section1end, int section2start, int section2end)
        {
            var section1 = new Section(section1start, section1end);
            var section2 = new Section(section2start, section2end);

            Assert.That(section1.Overlaps(section2), Is.False);
        }
    }
}