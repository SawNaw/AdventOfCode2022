// See https://aka.ms/new-console-template for more information

using Day01.Core;

var file = new FileParser(@"input.txt");
var result = file.Parse();

// Put a breakpoint here and inspect the contents of the result object.
Console.WriteLine("Top 3 elves carrying the most calories are:");
foreach (var item in result.CalorieAndPositions)
{
    Console.WriteLine($"  Elf at Position {item.Position}, carrying {item.HighestCalorie} calories");
}
Console.WriteLine($"In total, these elves are carrying {result.CalorieAndPositions.Sum(c => c.HighestCalorie)} calories.");
