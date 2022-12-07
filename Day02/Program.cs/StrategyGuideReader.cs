using Day02.Core.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.Core
{
    public static class StrategyGuideReader
    {
        public static IEnumerable<Round> ReadFromFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new ArgumentException($"No file named {file} could be found.");
            }

            var rounds = new List<Round>();

            foreach (var line in File.ReadAllLines(file)) 
            {
                rounds.Add(GetRoundFromLine(line));
            }

            return rounds;
        }

        private static Round GetRoundFromLine(string line)
        {
            var letters = line.Split(' ');
            return new Round(GetOpponentMoveFromLetter(letters[0]), GetYourMoveFromLetter(letters[1]));
        }

        private static OpponentMoves GetOpponentMoveFromLetter(string letter)
        {
            return letter switch
            {
                "A" => OpponentMoves.Rock,
                "B" => OpponentMoves.Paper,
                "C" => OpponentMoves.Scissors,
                _ => throw new ArgumentException($"{letter} is not a valid OpponentMove."),
            };
        }

        private static YourMoves GetYourMoveFromLetter(string letter)
        {
            return letter switch
            {
                "X" => YourMoves.Rock,
                "Y" => YourMoves.Paper,
                "Z" => YourMoves.Scissors,
                _ => throw new ArgumentException($"{letter} is not a valid YourMove.")
            };
        }

        // TODO
        //private static YourMoves GetNecessaryMoveForResult(OpponentMoves theirMove)
    }
}
