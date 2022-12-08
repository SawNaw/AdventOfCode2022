using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.Tests
{
    internal class IntegrationTests
    {
        [Test]
        public void TotalScore_ComputesCorrectly_ForPartOne()
        {
            var rounds = StrategyGuideReader.ReadFromFile(@"testinput.txt", StrategyGuideReader.ReadMode.PartOne);
            int score = 0;
            foreach (var round in rounds) 
            {
                score += round.GetTotalScore();
            }

            Assert.That(score, Is.EqualTo(15));
        }
    }
}
