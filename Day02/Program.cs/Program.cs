// See https://aka.ms/new-console-template for more information
using Day02.Core;
using System.Data;
using static Day02.Core.StrategyGuideReader;

Console.WriteLine("AdventOfCode -- Day02");
Console.WriteLine();
DoPartOne();
DoPartTwo();

static void DoPartOne()
{
    int score = GetScore(ReadMode.PartOne);

    Console.WriteLine($"Answer for Part One: The total score is {score}");
}

static void DoPartTwo()
{
    int score = GetScore(ReadMode.PartTwo);

    Console.WriteLine($"Answer for Part Two: The total score is {score}");
}

static int GetScore(ReadMode readMode)
{
    var rounds = StrategyGuideReader.ReadFromFile(@"input.txt", readMode);

    int score = 0;
    foreach (var round in rounds)
    {
        score += round.GetTotalScore();
    }

    return score;
}