using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03.Tests
{
    public class IntegrationTests
    {
        [Test]
        public void GetTotalPriorities_Works()
        {
            var result = Priority.GetSumOfPrioritiesOfAllCommonItems(@"testinput.txt");
            Assert.That(result, Is.EqualTo(157));
        }
    }
}
