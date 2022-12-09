using NUnit.Framework.Constraints;
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

        [Test]
        public void GetCommonItemInAllRucksacks_ReturnsExpected_TestOne()
        {
            List<Rucksack> sacks1 = new();
            sacks1.Add(new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp"));
            sacks1.Add(new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"));
            sacks1.Add(new Rucksack("PmmdzqPrVvPwwTWBwg"));

            Assert.That(Rucksack.GetCommonItemInAllRucksacks(sacks1), Is.EqualTo('r'));

            List<Rucksack> sacks2 = new();
            sacks2.Add(new Rucksack("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"));
            sacks2.Add(new Rucksack("ttgJtRGJQctTZtZT"));
            sacks2.Add(new Rucksack("CrZsJsPPZsGzwwsLwLmpwMDw"));

            Assert.Multiple(() =>
            {
                Assert.That(Rucksack.GetCommonItemInAllRucksacks(sacks1), Is.EqualTo('r'));
                Assert.That(Rucksack.GetCommonItemInAllRucksacks(sacks2), Is.EqualTo('Z'));
            });
            
        }
    }
}
