using Day05.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05.Tests
{
    internal class StacksOfCratesTests
    {
        [Test]
        public void Constructor_Works()
        {
            var lines = new FileReader(@"testinput.txt").GetLinesOfCratesFromFile();
            var stacks = new StacksOfCrates(lines);

            Assert.Multiple(() =>
            {
                Assert.That(stacks.Content.ElementAt(0).ElementAt(2), Is.EqualTo('Z'));
                Assert.That(stacks.Content.ElementAt(0).ElementAt(1), Is.EqualTo('N'));
                Assert.That(stacks.Content.ElementAt(0).ElementAt(0), Is.EqualTo(' '));

                Assert.That(stacks.Content.ElementAt(1).ElementAt(2), Is.EqualTo('M'));
                Assert.That(stacks.Content.ElementAt(1).ElementAt(1), Is.EqualTo('C'));
                Assert.That(stacks.Content.ElementAt(1).ElementAt(0), Is.EqualTo('D'));

                Assert.That(stacks.Content.ElementAt(2).ElementAt(2), Is.EqualTo('P'));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(1), Is.EqualTo(' '));
                Assert.That(stacks.Content.ElementAt(2).ElementAt(0), Is.EqualTo(' '));
            });
        }
    }
}
