using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EnumerableExtensions;

namespace Day11.Framework
{
    internal class Monkey
    {
        private readonly List<int> _items;
        public IReadOnlyList<int> Items => _items;
        public Func<int, int> Operation { get; private set; }
        public Test Test { get; private set; }

        public Monkey(Func<int, int> operation, Test test, params int[] startingItems)
        {
            this._items = startingItems.ToList();
            this.Operation = operation;
            this.Test = test;
        }

        public void Receive(int item)
        {
            _items.Add(item);
        }

        public void ThrowTo(Monkey targetMonkey)
        {
            var item = _items.First();
            _items.RemoveAt(0);
            targetMonkey.Receive(item);
        }

        public static IEnumerable<Monkey> GetMonkeysFromFile(string filePath)
        {
            var contents = File.ReadAllLines(filePath);
            return contents.Split(x => string.IsNullOrWhiteSpace(x))
                           .Select(x => GetFromTextBlock(x));
        }

        internal static Monkey GetFromTextBlock(IEnumerable<string> text)
        {
            var startingItems = text.ElementAt(1)                     // "  Starting items: 79, 98"
                                    .Replace("Starting items: ", "")  // "  79, 98"
                                    .Trim()                           // "79, 98"
                                    .Split(", ")                      // { "79", "98" }
                                    .Select(x => int.Parse(x))        // { 79, 98 }
                                    .ToArray();

            Func<int, int> operation = OperationParser.GetFromline(text.ElementAt(2));

            int divisor = int.Parse(text.ElementAt(3).Replace("Test: divisible by ", "").Trim());
            int targetIfTrue = int.Parse(text.ElementAt(4).Replace("If true: throw to monkey ", "").Trim());
            int targetIfFalse = int.Parse(text.ElementAt(5).Replace("If false: throw to monkey ", "").Trim());

            var test = new Test(divisor, targetIfTrue, targetIfFalse);

            return new Monkey(operation, test, startingItems);
        }
    }
}
