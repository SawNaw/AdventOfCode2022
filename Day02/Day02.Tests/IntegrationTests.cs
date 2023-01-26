namespace Day02.Tests
{
    internal class IntegrationTests
    {
        [Test]
        public void TotalScore_ComputesCorrectly_ForPartOne()
        {
            var rounds = StrategyGuideReader.GetAllRoundsFromFile(@"testinput.txt", StrategyGuideReader.ReadMode.PartOne);
            int score = 0;
            foreach (var round in rounds)
            {
                score += round.GetTotalScore();
            }

            Assert.That(score, Is.EqualTo(15));
        }

        [Test]
        public void TotalScore_ComputesCorrectly_ForPartTwo()
        {
            var rounds = StrategyGuideReader.GetAllRoundsFromFile(@"testinput.txt", StrategyGuideReader.ReadMode.PartTwo);
            int score = 0;
            foreach (var round in rounds)
            {
                score += round.GetTotalScore();
            }

            Assert.That(score, Is.EqualTo(12));
        }
    }
}
