using Day05.Core;

namespace Day05.Tests
{
    internal class LineOfCratesTests
    {
        [Test]
        public void Constructor_StoresItemsCorrectly_TestOne()
        {
            var lineOfCrates = new LineOfCrates("        [M]         [Q]     [P] [P]");

            Assert.Multiple(() =>
            {
                Assert.That(lineOfCrates.Content.ElementAt(0), Is.EqualTo(' '));
                Assert.That(lineOfCrates.Content.ElementAt(1), Is.EqualTo(' '));
                Assert.That(lineOfCrates.Content.ElementAt(2), Is.EqualTo('M'));
                Assert.That(lineOfCrates.Content.ElementAt(3), Is.EqualTo(' '));
                Assert.That(lineOfCrates.Content.ElementAt(4), Is.EqualTo(' '));
                Assert.That(lineOfCrates.Content.ElementAt(5), Is.EqualTo('Q'));
                Assert.That(lineOfCrates.Content.ElementAt(6), Is.EqualTo(' '));
                Assert.That(lineOfCrates.Content.ElementAt(7), Is.EqualTo('P'));
                Assert.That(lineOfCrates.Content.ElementAt(8), Is.EqualTo('P'));
            });
        }

        [Test]
        public void Constructor_StoresItemsCorrectly_TestTwo()
        {
            var lineOfCrates = new LineOfCrates("        [V] [T] [N] [J] [W] [B] [W]");

            Assert.Multiple(() =>
            {
                Assert.That(lineOfCrates.Content.ElementAt(0), Is.EqualTo(' '));
                Assert.That(lineOfCrates.Content.ElementAt(1), Is.EqualTo(' '));
                Assert.That(lineOfCrates.Content.ElementAt(2), Is.EqualTo('V'));
                Assert.That(lineOfCrates.Content.ElementAt(3), Is.EqualTo('T'));
                Assert.That(lineOfCrates.Content.ElementAt(4), Is.EqualTo('N'));
                Assert.That(lineOfCrates.Content.ElementAt(5), Is.EqualTo('J'));
                Assert.That(lineOfCrates.Content.ElementAt(6), Is.EqualTo('W'));
                Assert.That(lineOfCrates.Content.ElementAt(7), Is.EqualTo('B'));
                Assert.That(lineOfCrates.Content.ElementAt(8), Is.EqualTo('W'));
            });
        }

        [Test]
        public void Constructor_StoresItemsCorrectly_TestThree()
        {
            var lineOfCrates = new LineOfCrates("[Q] [Q] [M] [Z] [Z] [N] [G] [G] [J]");

            Assert.Multiple(() =>
            {
                Assert.That(lineOfCrates.Content.ElementAt(0), Is.EqualTo('Q'));
                Assert.That(lineOfCrates.Content.ElementAt(1), Is.EqualTo('Q'));
                Assert.That(lineOfCrates.Content.ElementAt(2), Is.EqualTo('M'));
                Assert.That(lineOfCrates.Content.ElementAt(3), Is.EqualTo('Z'));
                Assert.That(lineOfCrates.Content.ElementAt(4), Is.EqualTo('Z'));
                Assert.That(lineOfCrates.Content.ElementAt(5), Is.EqualTo('N'));
                Assert.That(lineOfCrates.Content.ElementAt(6), Is.EqualTo('G'));
                Assert.That(lineOfCrates.Content.ElementAt(7), Is.EqualTo('G'));
                Assert.That(lineOfCrates.Content.ElementAt(8), Is.EqualTo('J'));
            });
        }
    }
}

