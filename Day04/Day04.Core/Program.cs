// See https://aka.ms/new-console-template for more information
using Day04.Core;

Console.WriteLine("Advent of Code -- Day 04");
Console.WriteLine();

var reader = new SectionAssignmentReader(@"input.txt");

Console.WriteLine($"Answer to Part One: {reader.GetFullyContainedPairs()}");

Console.WriteLine($"Answer to Part Two: {reader.GetOverlappingPairs()}");
