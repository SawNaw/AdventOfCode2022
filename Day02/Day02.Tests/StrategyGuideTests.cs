﻿using Day02.Core.Moves;

namespace Day02.Tests
{
    internal class StrategyGuideTests
    {
        [Test]
        public void ReadFromFile_Returns_CorrectRounds()
        {
            var rounds = StrategyGuideReader.GetAllRoundsFromFile(@"testinput.txt", StrategyGuideReader.ReadMode.PartOne);
            var t = rounds.ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(rounds.ElementAt(0).OpponentsMove, Is.EqualTo(OpponentMoves.Rock));
                Assert.That(rounds.ElementAt(0).YourMove, Is.EqualTo(YourMoves.Paper));
                Assert.That(rounds.ElementAt(1).OpponentsMove, Is.EqualTo(OpponentMoves.Paper));
                Assert.That(rounds.ElementAt(1).YourMove, Is.EqualTo(YourMoves.Rock));
                Assert.That(rounds.ElementAt(2).OpponentsMove, Is.EqualTo(OpponentMoves.Scissors));
                Assert.That(rounds.ElementAt(2).YourMove, Is.EqualTo(YourMoves.Scissors));
            });
        }
    }
}
