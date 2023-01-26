namespace Day11.Framework
{
    internal static class OperationParser
    {
        internal static Func<int, int> GetFromline(string line)
        {
            if (line.EndsWith("* old"))
            {
                return (x) => x * x;
            }
            else
            {
                string[] twoOperandsAndOperator = line.Replace("Operation: new = ", "")
                                        .Trim()
                                        .Split(' ');

                int factor = int.Parse(twoOperandsAndOperator.Last());

                return twoOperandsAndOperator.ElementAt(1) == "*"
                                           ? (x) => x * factor
                                           : (x) => x + factor;
            }
        }
    }
}