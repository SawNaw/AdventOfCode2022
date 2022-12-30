using Day09.RopeMotionSimulator;

Console.WriteLine("Advent Of Code: Day 9");
Console.WriteLine("");

var simulator = new MotionSimulator(@"input.txt", 2);

Console.WriteLine($"Answer to Part 1: {simulator.ExecuteAllInstructions()}");

Console.WriteLine("");

simulator = new MotionSimulator(@"input.txt", 10);

Console.WriteLine($"Answer to Part 2: {simulator.ExecuteAllInstructions()}");