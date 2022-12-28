using Day07.Filesystem;

Console.WriteLine("Advent Of Code -- Day 07");
Console.WriteLine("");

var fileSystem = new FileSystem(@"input.txt");
fileSystem.ProcessFile();

Console.WriteLine("Answer to Part One");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: {fileSystem.GetTotalSizeForPartOne()}");

Console.WriteLine("");

Console.WriteLine("Answer to Part Two");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: ");