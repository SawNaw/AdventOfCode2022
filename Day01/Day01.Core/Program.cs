// See https://aka.ms/new-console-template for more information

using Day01.Core;
Console.WriteLine("Advent of Code -- Day 01");
Console.WriteLine();

var file = new FileParser(@"input.txt");
var result = file.CalculateTotalCaloriesOfEachElf();

Console.WriteLine("Answer to Part 1");
Console.WriteLine("------------------");
Console.WriteLine($"The elf carrying the most calories is carrying {result.Max()} calories.");
Console.WriteLine();
Console.WriteLine("Answer to Part 2");
Console.WriteLine("------------------");
Console.WriteLine($"The top three elves are carrying {Calculator.SumThreeHighest(result)} calories.");

