// See https://aka.ms/new-console-template for more information
using Day05.Core;

Console.WriteLine("Advent Of Code -- Day05");
Console.WriteLine("");

var reader = new FileReader(@"input.txt");
var linesOfCrates = reader.GetLinesOfCratesFromFile();
var instructions = reader.GetInstructionsFromFile();
var stacks = new StacksOfCrates(linesOfCrates);

string message = stacks.ExecuteInstructions(instructions, CrateMoverVersions.CrateMover9000);

Console.WriteLine("Answer to Part One");
Console.WriteLine("--------------------------");
Console.WriteLine($"The message is: {message}");

stacks = new StacksOfCrates(linesOfCrates);
message = stacks.ExecuteInstructions(instructions, CrateMoverVersions.CrateMover9001);
Console.WriteLine("Answer to Part Two");
Console.WriteLine("--------------------------");
Console.WriteLine($"The message is: {message}");
