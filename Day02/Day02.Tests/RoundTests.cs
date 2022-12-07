using Day02.Core.Moves;

namespace Day02.Tests
{
    public class Tests
    {
        [TestCase(OpponentMoves.Rock, YourMoves.Paper, 8)]
        [TestCase(OpponentMoves.Paper, YourMoves.Rock, 1)]
        [TestCase(OpponentMoves.Scissors, YourMoves.Scissors, 6)]
        public void Execute_ReturnsCorrectScore(OpponentMoves opponentMove, YourMoves yourMove, int expectedScore)
        {
            var s = new Round(opponentMove, yourMove);
            var score = s.GetTotalScore();
            Assert.That(score, Is.EqualTo(expectedScore));
        }
    }
}