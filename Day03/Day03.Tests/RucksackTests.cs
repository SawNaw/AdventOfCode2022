using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03.Tests
{
    public class RucksackTests
    {
        [Test]
        public void GetFirstCompartment_ReturnsExpected()
        {
            var rucksack = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");
            Assert.That(rucksack.GetFirstCompartment(), Is.EqualTo("vJrwpWtwJgWr"));
        }

        [Test]
        public void GetSecondCompartment_ReturnsExpected()
        {
            var rucksack = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");
            Assert.That(rucksack.GetSecondCompartment(), Is.EqualTo("hcsFMMfFFhFp"));
        }

        [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
        [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
        [TestCase("PmmdzqPrVvPwwTWBwg", 'P')]
        [TestCase("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
        [TestCase("ttgJtRGJQctTZtZT", 't')]
        [TestCase("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
        public void GetCommonItem_ReturnsExpected(string s, char expected)
        {
            var rucksack = new Rucksack(s);
            Assert.That(rucksack.GetCommonItem(), Is.EqualTo(expected));
        }
    }
}
