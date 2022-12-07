using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Tests
{
    internal class FileParserTests
    {
        public class CalorieListTests
        {
            [Test]
            public void Parse_Returns_CorrectNumberOfLists()
            {
                var parser = new FileParser(@"testinput.txt");
                var result = parser.Parse();
                Assert.That(result.Elves.Count, Is.EqualTo(5));
            }

            [Test]
            public void Parse_Returns_ElfWithMostCalories()
            {
                var parser = new FileParser(@"testinput.txt");
                var result = parser.Parse();
                //Assert.That(result., Is.EqualTo(3));
            }
        }
    }
}
