namespace Day05.Core
{
    internal class MoveInstruction
    {
        public int NumberOfItemsToMove { get; }
        public int Source { get; }
        public int Destination { get; }
        public MoveInstruction(string text)
        {
            var numbersOnly = text.Replace("move ", " ")
                                  .Replace(" from ", " ")
                                  .Replace(" to ", " ")
                                  .Trim()
                                  .Split(" ")
                                  .Select(x => int.Parse(x));

            this.NumberOfItemsToMove = numbersOnly.ElementAt(0);
            this.Source = numbersOnly.ElementAt(1);
            this.Destination = numbersOnly.ElementAt(2);
        }
    }
}
