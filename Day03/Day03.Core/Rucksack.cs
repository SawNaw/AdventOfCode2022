using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Day03.Core
{
    internal class Rucksack
    {
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
            return first.Where(c => second.Contains(c)).Distinct().Single();
        }
    }
}
