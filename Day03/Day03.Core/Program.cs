// See https://aka.ms/new-console-template for more information
using Day03.Core;

Console.WriteLine("Advent of Code -- Day 03");
Console.WriteLine("");

var answerPartOne = Priority.GetSumOfPrioritiesOfAllCommonItems(@"input.txt");
Console.WriteLine($"Answer to Part One is: {answerPartOne}");

var answerPartTwo = Priority.GetSumOfPrioritiesOfAllThreeElfGroups(@"input.txt");
Console.WriteLine($"Answer to Part Two is: {answerPartTwo}");
