// See https://aka.ms/new-console-template for more information
using Day02.Core;

Console.WriteLine("Day02 - Part One");

DoPartOne();

static void DoPartOne()
{
    var rounds = StrategyGuideReader.ReadFromFile(@"input.txt");

    int score = 0;
    foreach (var round in rounds)
    {
        score += round.GetTotalScore();
    }

    Console.WriteLine($"Answer: {score}");
}

static void DoPartTwo()
{
    Console.WriteLine($"To be continued...");
}