using Day06.Core;

Console.WriteLine("Advent Of Code -- Day06");
Console.WriteLine("");

var fileContent = File.ReadAllText(@"input.txt");

var stream = new Datastream(fileContent);

// Collections are zero-based, the problem is not, therefore adjust by one.
var answerOne = stream.FindFirstStartOfPacketMarker().MarkerPosition + 1;

Console.WriteLine("Answer to Part One");
Console.WriteLine("--------------------------");
Console.WriteLine($"The answer is: {answerOne}");

Console.WriteLine("");


Console.WriteLine("Answer to Part Two");
Console.WriteLine("--------------------------");
Console.WriteLine($"blahblah");