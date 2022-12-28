using Day07.Filesystem;

Console.WriteLine("Advent Of Code -- Day 07");
Console.WriteLine("");

var fileSystem = new FileSystem(@"input.txt");
fileSystem.ProcessFile();

Console.WriteLine("Answer to Part One");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: {fileSystem.GetTotalSizeForPartOne(fileSystem.RootDirectory)}");

Console.WriteLine("");

fileSystem.GetDeletionCandidatesForPartTwo(fileSystem.RootDirectory);

Console.WriteLine("Answer to Part Two");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: {fileSystem.DeletionCandidates.MinBy(d => d.Size).Size}");