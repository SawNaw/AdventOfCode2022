using Day08.Trees;

Console.WriteLine("Advent Of Code -- Day 08");
Console.WriteLine("");

var forest = new Forest(@"input.txt");

Console.WriteLine("Answer to Part One");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: {forest.GetNumberOfVisibleTrees()}");

Console.WriteLine("");


Console.WriteLine("Answer to Part Two");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: ");