// See https://aka.ms/new-console-template for more information

using Day01.Core;

var file = new FileParser(@"input.txt");
var result = file.Parse();

// Put a breakpoint here and inspect the contents of the result object.
Console.WriteLine("Done!");
