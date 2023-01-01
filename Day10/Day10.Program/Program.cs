using Day10.CPU;

Console.WriteLine("Advent Of Code: Day 10");
Console.WriteLine("");

var cpu = new Cpu(@"input.txt");
cpu.RunProgram();

var answer1 = new[] 
{
    cpu.SignalStrengths[19],
    cpu.SignalStrengths[59],
    cpu.SignalStrengths[99],
    cpu.SignalStrengths[139],
    cpu.SignalStrengths[179],
    cpu.SignalStrengths[219],
}.Sum();


Console.WriteLine($"Answer to Part 1: {answer1}");

Console.WriteLine($"Answer to Part 2: ");