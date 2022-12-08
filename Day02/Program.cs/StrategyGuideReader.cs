using Day02.Core.Moves;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02.Core
{
    public static class StrategyGuideReader
    {
        public static IEnumerable<Round> ReadFromFile(string file, ReadMode readMode)
        {
            if (!File.Exists(file))
            {
                throw new ArgumentException($"No file named {file} could be found.");
            }

            var rounds = new List<Round>();

            foreach (var line in File.ReadAllLines(file)) 
            {
                if (readMode == ReadMode.PartOne)
                {
                    rounds.Add(GetRoundFromLine(line));
                }
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

        private static YourMoves GetYourMoveFromTwoLetters(string[] letters)
        {
            return letters[0] switch
            {
                "A" when letters[1] == "X" => YourMoves.Scissors,
                "A" when letters[1] == "Y" => YourMoves.Rock,
                "A" when letters[1] == "Z" => YourMoves.Paper,

                "B" when letters[1] == "X" => YourMoves.Rock,
                "B" when letters[1] == "Y" => YourMoves.Paper,
                "B" when letters[1] == "Z" => YourMoves.Scissors,

                "C" when letters[1] == "X" => YourMoves.Paper,
                "C" when letters[1] == "Y" => YourMoves.Scissors,
                "C" when letters[1] == "Z" => YourMoves.Rock,

                _ => throw new ArgumentException($"{letters[0]} is not a valid move.")
            };
        }

        public enum ReadMode
        {
            PartOne,
            PartTwo,
        }
    }
}
