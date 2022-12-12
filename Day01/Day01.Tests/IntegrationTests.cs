using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Tests
{
    internal class IntegrationTests
    {
        [Test]
        public void IntegrationTest_ForPartTwo_UsingTestInput()
        {
            var parser = new FileParser(@"testinput.txt");
            var result = parser.Parse();
            var sumofAllHighestCalories = result.CalorieAndPositions.Sum(c => c.HighestCalorie);
            Assert.That(sumofAllHighestCalories, Is.EqualTo(45000));
        }
    }
}
