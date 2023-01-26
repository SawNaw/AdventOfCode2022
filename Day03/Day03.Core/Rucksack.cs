namespace Day03.Core
{
    internal class Rucksack
    {
        public string Content => items;
        private string items;

        public Rucksack(string items)
        {
            this.items = items;
        }

        public string GetFirstCompartment()
        {
            return items.Substring(0, items.Length / 2);
        }

        public string GetSecondCompartment()
        {
            return items.Substring(items.Length / 2, items.Length / 2);
        }

        public char GetCommonItem()
        {
            var first = GetFirstCompartment();
            var second = GetSecondCompartment();

            return first.Where(c => second.Contains(c))
                        .Distinct()
                        .Single();
        }

        public static char GetCommonItemInAllRucksacks(IEnumerable<Rucksack> sacks)
        {
            var s1 = sacks.First().Content;
            var s2 = sacks.ElementAt(1).Content;
            var s3 = sacks.ElementAt(2).Content;

            return s1.Where(s => s2.Contains(s) && s3.Contains(s))
                     .Distinct()
                     .Single();
        }
    }
}
