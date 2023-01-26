using Day02.Core.Moves;

namespace Day02.Core
{
    public class Round
    {
        public OpponentMoves OpponentsMove => opponentsMove;
        public YourMoves YourMove => yourMove;
        private readonly OpponentMoves opponentsMove;
        private readonly YourMoves yourMove;

        public Round(OpponentMoves opponentsMove, YourMoves yourMove)
        {
            this.opponentsMove = opponentsMove;
            this.yourMove = yourMove;
        }

        public int GetTotalScore()
        {
            return (int)yourMove + GetOutcomeScore();
        }

        private int GetOutcomeScore()
        {
            return opponentsMove switch
            {
                OpponentMoves.Rock when yourMove == YourMoves.Rock => Scores.Draw,
                OpponentMoves.Rock when yourMove == YourMoves.Paper => Scores.Win,
                OpponentMoves.Rock when yourMove == YourMoves.Scissors => Scores.Lose,

                OpponentMoves.Paper when yourMove == YourMoves.Rock => Scores.Lose,
                OpponentMoves.Paper when yourMove == YourMoves.Paper => Scores.Draw,
                OpponentMoves.Paper when yourMove == YourMoves.Scissors => Scores.Win,

                OpponentMoves.Scissors when yourMove == YourMoves.Rock => Scores.Win,
                OpponentMoves.Scissors when yourMove == YourMoves.Paper => Scores.Lose,
                OpponentMoves.Scissors when yourMove == YourMoves.Scissors => Scores.Draw,

                _ => throw new ArgumentException("Unrecognised Opponent Move."),
            };
        }

        private static class Scores
        {
            public const int Win = 6;
            public const int Draw = 3;
            public const int Lose = 0;
        }
    }
}