using Day09.RopeMotionSimulator;

Console.WriteLine("Advent Of Code -- Day 09");
Console.WriteLine("");

var simulator = new MotionSimulator(@"input.txt", MotionSimulator.Modes.PartOne);

Console.WriteLine("Answer to Part One");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: {simulator.ExecuteInstructions()}");

Console.WriteLine("");


Console.WriteLine("Answer to Part Two");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: ");